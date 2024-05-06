import { useState } from "react";
import axios from "axios";
import { useNavigate, Link } from "react-router-dom";
import { toast } from "react-toastify";
import { VITE_BACKEND_URL } from "../App";

const LoginPage = () => {

    const [email, setEmail] = useState("");
    const [senha, setSenha] = useState("");
    const [isLoading, setIsLoading] = useState(false);
    const navigate = useNavigate();

    const Login = async(e) => {
        e.preventDefault();
        if(email === "" || senha === ""){
            alert('Preencha todos os campos!'); 
            return;
        }
        try{
            setIsLoading(true);
            const response = await axios.post(`${VITE_BACKEND_URL}api/Login`, {email: email, senha: senha});
            toast.success(`Bem-vindo ${response.data.nome} `);
            sessionStorage.setItem("id", response.data.id)
            sessionStorage.setItem("nome", response.data.nome)
            sessionStorage.setItem("email", response.data.email)
            sessionStorage.setItem("token", response.data.token)
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
                Login
            </h2>
            <form onSubmit={Login}>
                <div className="space-y-2">
                    <div>
                        <label>Email</label>
                        <input type="email" value={email} onChange={(e) => setEmail(e.target.value)} className="w-full block border p-3 text-gray-600 rounded focus:outline-none focus:shadow-outline focus:border-blue-200 placeholder-gray-400" placeholder="exemplo@email.com" />
                    </div>
                    <div>
                        <label>Senha</label>
                        <input type="password" value={senha} onChange={(e) => setSenha(e.target.value)} className="w-full block border p-3 text-gray-600 rounded focus:outline-none focus:shadow-outline focus:border-blue-200 placeholder-gray-400" placeholder="*****" />
                    </div>
                    <div>
                        { !isLoading && ( <button className="block w-full mt-6 bg-blue-700 text-white rounded-sm px-4 py-2 font-bold hover:bg-blue-600 hover:cursor-pointer">Login</button>)}         
                    </div>
                    <div>
                        { !isLoading && ( <Link to="/register"> <button className="block w-full mt-6 bg-blue-700 text-white rounded-sm px-4 py-2 font-bold hover:bg-blue-600 hover:cursor-pointer">Cadastrar-se</button> </Link>)}         
                    </div>

                </div>
            </form>
        </div>
    )
}


export default LoginPage;