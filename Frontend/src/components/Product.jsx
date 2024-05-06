import axios from "axios";
import { Link } from "react-router-dom";
import { toast } from "react-toastify";
import Swal from "sweetalert2";
import { VITE_BACKEND_URL } from "../App";

/* eslint-disable react/prop-types */
const Product = ({ product, getProducts }) => {

    const deleteProduct = async (id) => {
        const result = await Swal.fire({
            title: 'Você quer realmente deletar o produto?',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Sim!'

        })
        if(result.isConfirmed){
            try{
                var token = sessionStorage.getItem("token");
                await axios.delete(`${VITE_BACKEND_URL}api/Produto/${id}`,{
                headers: {
                    'Authorization': `Bearer ${token}`,
                    'Content-Type': 'application/json'
                  }
            });
                toast.success("Deletado com sucesso");
                getProducts();
            }catch(error){
                toast.error(error.message);
            }
        }

    }

    return (
        <div className="bg-white rounded shadow-lg overflow-hidden">
            <div className="px-4 pt-2 pb-4">
                <h2 className="text font-semibold">{product.nome}</h2>
                <div className="text-sm">Descricao: {product.descricao}</div>
                <div className="text-sm">Preço R${product.preco}</div>
                <div className="text-sm ">COD:{product.codigoProduto}</div>

                <div className="mt-2 flex gap-4">
                    <Link to={`/edit/${product.id}`} className="inline-block w-full text-center shadow-md text-sm bg-gray-700 text-white rounded-sm px-4 py-1 font-bold hover:bg-gray-600 hover:cursor-pointer">Edit</Link>
                    <button onClick={() => deleteProduct(product.id)}  className="inline-block w-full text-center shadow-md text-sm bg-red-700 text-white rounded-sm px-4 py-1 font-bold hover:bg-red-600 hover:cursor-pointer">Delete</button>
                </div>


            </div>
         

        </div>
    )
}

export default Product;
