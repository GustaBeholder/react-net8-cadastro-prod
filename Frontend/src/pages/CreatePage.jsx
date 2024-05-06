import { useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import { toast } from "react-toastify";
import { VITE_BACKEND_URL } from "../App";

const CreatePage = () => {

    const [nome, setNome] = useState("");
    const [descricao, setDescricao] = useState("");
    const [preco, setPreco] = useState("");
    const [codigoProduto, setCodigoProduto] = useState("");
    const [isLoading, setIsLoading] = useState(false);
    const navigate = useNavigate();

    const saveProduct = async(e) => {
        e.preventDefault();
        if(nome === "" || descricao === "" || preco === ""){
            alert('Preencha todos os campos!'); 
            return;
        }
        try{
            setIsLoading(true);
            let token = sessionStorage.getItem("token");
            let id = sessionStorage.getItem("id");
            const response = await axios.post(`${VITE_BACKEND_URL}api/Produto`, {nome: nome, descricao: descricao, preco: preco, codigoProduto: codigoProduto, idCriador: id},
            {
                headers: {
                    'Authorization': `Bearer ${token}`,
                    'Content-Type': 'application/json'
                  }
            }
            );
            toast.success(`Salvou ${response.data.nome} com sucesso`);
            setIsLoading(false);
            navigate("/");
        }catch (error){
            toast.error(error.message);
            setIsLoading(false);
        }
    }

    return (
        <div className="max-w-lg bg-white shadow-lg mx-auto p-7 rounded mt-6">
            <h2 className="font-semibold text-2xl mb-4 block text-center">
                Cadastre um Produto
            </h2>
            <form onSubmit={saveProduct}>
                <div className="space-y-2">
                    <div>
                        <label>Nome</label>
                        <input type="text" value={nome} onChange={(e) => setNome(e.target.value)} className="w-full block border p-3 text-gray-600 rounded focus:outline-none focus:shadow-outline focus:border-blue-200 placeholder-gray-400" placeholder="Nome.." />
                    </div>
                    <div>
                        <label>Descricao</label>
                        <input type="text" value={descricao} onChange={(e) => setDescricao(e.target.value)} className="w-full block border p-3 text-gray-600 rounded focus:outline-none focus:shadow-outline focus:border-blue-200 placeholder-gray-400" placeholder="Descricao" />
                    </div>
                    <div>
                        <label>Código Produto</label>
                        <input type="text" value={codigoProduto} onChange={(e) => setCodigoProduto(e.target.value)} className="w-full block border p-3 text-gray-600 rounded focus:outline-none focus:shadow-outline focus:border-blue-200 placeholder-gray-400" placeholder="COD-4567" />
                    </div>
                    <div>
                        <label>Preco</label>
                        <input type="number" value={preco} onChange={(e) => setPreco(e.target.value)} className="w-full block border p-3 text-gray-600 rounded focus:outline-none focus:shadow-outline focus:border-blue-200 placeholder-gray-400" placeholder="Preço R$" />
                    </div>
                    <div>
                        { !isLoading && ( <button className="block w-full mt-6 bg-blue-700 text-white rounded-sm px-4 py-2 font-bold hover:bg-blue-600 hover:cursor-pointer">Criar</button>)}         
                    </div>
                </div>
            </form>
        </div>
    )
}


export default CreatePage;