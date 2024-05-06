import { useEffect, useState } from "react";
import axios from "axios";
import Product from "../components/Product"
import { Link, useNavigate } from "react-router-dom";
import { VITE_BACKEND_URL } from "../App";

const HomePage = () => {

    const [products, setProducts] = useState([]);
    const [query, setQuery] = useState("");
    const [isLoading, setIsLoading] = useState(false);
    const navigate = useNavigate();

    const getProducts = async () => {
        try{
            let token = sessionStorage.getItem("token");
            
           setIsLoading(true); 
           const response = await axios.get(`${VITE_BACKEND_URL}api/Produto?query=${query}`, {
            headers: {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json'
              }
           });
           console.log(response.data);
           setProducts(response.data);
           setIsLoading(false);

        } catch (error){
           console.log(error);
        }
    }

    useEffect(() => {
        let token = sessionStorage.getItem("token");

        if(token === null) navigate("/login");

        getProducts();
    }, [])

    return (
        <div>

                <div className="grid grid-cols-2 lg:grid-cols-4 gap-4 mt-5">
                    <div>
                        <input type="text" value={query} onChange={(e) => setQuery(e.target.value)} className="w-full block border p-3 text-gray-600 rounded focus:outline-none focus:shadow-outline focus:border-blue-200 placeholder-gray-400" placeholder="Pesquisar por nome..." />
                        <button type="button" onClick={getProducts} className="block w-full mt-6 bg-blue-700 text-white rounded-sm px-4 py-2 font-bold hover:bg-blue-600 hover:cursor-pointer">Pesquisar</button>
                    </div>
                </div>

            
            
            <div>
                <Link to="/create" className="inline-block mt-4 shadow-md bg-blue-700 text-white rounded-sm px-4 py-2 font-bold hover:bg-blue-600 hover:cursor-pointer">
                    Cadastre um Produto
                </Link>
            </div>
            
            <div className="grid grid-cols-2 lg:grid-cols-4 gap-4 mt-5">
                {isLoading ? (
                    "Loading"
                ) : (
                    <>
                    {products.length > 0 ? (
                        <>

                            {
                                products.map((product, index) => {
                                   return (
                                     <Product key={index} product={product} getProducts={getProducts}/>
                                   )
                                })
                            }
                        </>
                    ) : (
                        <div>
                            Não há produtos a serem mostrados!
                        </div>
                    )}
                    
                    </>
                )}
            </div>
        </div>
    )
}


export default HomePage;