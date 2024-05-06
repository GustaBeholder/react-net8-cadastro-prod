import axios from "axios";
import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { toast } from "react-toastify";
import { VITE_BACKEND_URL } from "../App";

const EditPage = () => {
    let { id } = useParams();
    const navigate = useNavigate();
    const [isLoading, setIsLoading] = useState(false);
    const [ product, setProduct] = useState({
        id: "",
        nome: "",
        descricao: "",
        preco: "",
        codproduto: "",
    });

    const getProduct = async () => {
        setIsLoading(true);
        try{
            let token = sessionStorage.getItem("token");
            const response = await axios.get(`${VITE_BACKEND_URL}api/Produto/${id}`, {
                headers: {
                    'Authorization': `Bearer ${token}`,
                    'Content-Type': 'application/json'
                  }
            });
            setProduct({
                id: response.data.id,
                nome: response.data.nome,
                descricao: response.data.descricao,
                preco: response.data.preco,
                codigoProduto: response.data.codigoProduto,
            })
            setIsLoading(false);

        }catch(error){
            setIsLoading(false);
            toast.error(error.message);
        }
     

    }

    const updateProduct = async (e) => {
        e.preventDefault();
        setIsLoading(true);
        try{
            let token = sessionStorage.getItem("token");

            await axios.put(`${VITE_BACKEND_URL}api/Produto/`, product, {
                headers: {
                    'Authorization': `Bearer ${token}`,
                    'Content-Type': 'application/json'
                  }
            });
            toast.success("Produto Atualizado com sucesso");
            navigate('/');
        }catch(error){
            setIsLoading(false);
            toast.error(error.message);
        }
    }

    useEffect(() => {
        let token = sessionStorage.getItem("token");

        if(token === null) navigate("/login");
        getProduct();
    }, [])

    return (
    <div className="max-w-lg bg-white shadow-lg mx-auto p-7 rounded mt-6">
        <h2 className="font-semibold text-2xl mb-4 block text-center">
            Atualizar Produto
        </h2>
        { isLoading ? ("Loading") : (
            <>
                <form onSubmit={updateProduct}>
                    <div className="space-y-2">
                        <div>
                            <label>Nome</label>
                            <input type="text" value={product.nome} onChange={(e) => setProduct({...product, nome: e.target.value})}  className="w-full block border p-3 text-gray-600 rounded focus:outline-none focus:shadow-outline focus:border-blue-200 placeholder-gray-400" placeholder="Enter Name" />
                        </div>
                        <div>
                            <label>Descricao</label>
                            <input type="text" value={product.descricao} onChange={(e) => setProduct({...product, descricao: e.target.value})}  className="w-full block border p-3 text-gray-600 rounded focus:outline-none focus:shadow-outline focus:border-blue-200 placeholder-gray-400" placeholder="Enter Quantity" />
                        </div>
                        <div>
                            <label>Preco</label>
                            <input type="number" value={product.preco} onChange={(e) => setProduct({...product, preco: e.target.value})} className="w-full block border p-3 text-gray-600 rounded focus:outline-none focus:shadow-outline focus:border-blue-200 placeholder-gray-400" placeholder="Enter Price" />
                        </div>
                        <div>
                            <label>Código Produto</label>
                            <input type="text" value={product.codigoProduto} onChange={(e) => setProduct({...product, codigoProduto: e.target.value})}  className="w-full block border p-3 text-gray-600 rounded focus:outline-none focus:shadow-outline focus:border-blue-200 placeholder-gray-400" placeholder="Enter Image URL" />
                        </div>
                        <div>
                            { !isLoading && ( <button className="block w-full mt-6 bg-blue-700 text-white rounded-sm px-4 py-2 font-bold hover:bg-blue-600 hover:cursor-pointer">Atualizar</button>)}         
                        </div>
                    </div>
                </form>
            </>
        )}

    </div>
    )
}


export default EditPage;