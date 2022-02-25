import React, {useState, useEffect, useCallback} from "react";
import {Link, useHistory} from 'react-router-dom';
import './styles.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import Pagination from "../../Pagination/Pagination";

import api from "../../services/api";

import {FiEdit} from 'react-icons/fi';
import {AiOutlineDelete} from 'react-icons/ai'

import logo from '../../assets/viagem.png';

export default function PontosTuristicos(){

    const [searchInput,setSearchInput]  = useState('');
    const [filtro, setFiltro] = useState([]);
    const [exibirDetalhes, setExibirDetalhes] = useState(0);
    const [offset, setOffset] = useState(0);

    const[pontosTuristicos,setPontosTuristicos] = useState([]);

    console.log(pontosTuristicos.length);

    const searchPontosTuristicos = (searchValue) => {
        setSearchInput(searchValue);
        if (searchInput !== '') {
            const dadosFiltrados = pontosTuristicos.filter((item) => {
                return Object.values(item).join('').toLowerCase()
                .includes(searchInput.toLowerCase())
            });
            setFiltro(dadosFiltrados);
        }
        else{
            setFiltro(pontosTuristicos);
        }
      }
    
    useEffect( ()=> {
      api.get("/PontosTuristicos").then(
          (response)=> setPontosTuristicos(response.data))  
          .catch((error) => {
            console.error("ops! ocorreu um erro" + error);
          });
      }, []);

      const history = useHistory();

      async function editPontoTuristico(id){
          try{
            history.push(`pontoTuristico/novo/${id}`)
          }catch(error){
              alert('Não foi possível editar o ponto turístico')
          }
      }

      async function deletePontoTuristico(id){
        try{
           if(window.confirm('Deseja mesmo excluir esse ponto turístico?'))
           {
                 await api.delete(`/pontosTuristicos/${id}`);
                 setPontosTuristicos(pontosTuristicos.filter(pontoTuristico => pontoTuristico.id !== id));
           }
        }catch(error){
         alert('Não foi possível excluir')
        }
      }

    const handleExibirDetalhes = useCallback ((id) => {
        setExibirDetalhes(exibirDetalhes ? 0 : id)
    }, [setExibirDetalhes])

     return(
         <div className="pontoTuristico-container">
             <header>
                <img src={logo} alt="logo" />
                <h1>NewCon - Pontos Turísticos</h1>
                <Link className="btn btn-success btn-lg" to="pontoTuristico/novo/0">Cadastrar um Ponto Turistico</Link>
             </header>
             <br />
             <form class="input-group input-group-lg">
                 <input class="form-control" type="text" placeholder="Digite um termo para buscar um ponto turístico..."
                 onChange={(e) => searchPontosTuristicos(e.target.value)}
                 />
             </form>
             <br />

            {searchInput.length > 1 ? (
                <ul>
                {filtro.map(pontoTuristico=>(
                    <li key={pontoTuristico.id}>
                        {pontoTuristico.nome}<br /><br />
                        {pontoTuristico.localizacao}<br /><br /> 
                        {pontoTuristico.id === exibirDetalhes && (
                            pontoTuristico.descricao
                        )} 
                        {pontoTuristico.id === exibirDetalhes && (
                            <button className="btn btn-secondary btn-sm" onClick={() => handleExibirDetalhes(0)}>Ocultar Detalhes</button>
                        )}
                        {pontoTuristico.id !== exibirDetalhes && (
                            <button className="btn btn-secondary btn-sm" onClick={() => handleExibirDetalhes(pontoTuristico.id)}>Ver Detalhes</button>
                        )}                      
                        <button type="button" onClick={()=> editPontoTuristico(pontoTuristico.id)}>
                            <FiEdit size="25" color="blue"/>
                        </button>
                        <button type="button" onClick={() => deletePontoTuristico(pontoTuristico.id)}>
                            <AiOutlineDelete size="25" color="red"/>
                        </button>
                        </li>
                    ))}
                </ul>
            ) : (
            <ul>
                {pontosTuristicos.map(pontoTuristico=>(
                    <li key={pontoTuristico.id}>
                        {pontoTuristico.nome}<br /><br />
                        {pontoTuristico.localizacao}<br /><br />
                        {pontoTuristico.id === exibirDetalhes && (
                            pontoTuristico.descricao
                        )} 
                        {pontoTuristico.id === exibirDetalhes && (
                            <button className="btn btn-secondary btn-sm" onClick={() => handleExibirDetalhes(0)}>Ocultar Detalhes</button>
                        )}
                        {pontoTuristico.id !== exibirDetalhes && (
                            <button className="btn btn-secondary btn-sm" onClick={() => handleExibirDetalhes(pontoTuristico.id)}>Ver Detalhes</button>
                        )}                
                    <button type="button" onClick={()=> editPontoTuristico(pontoTuristico.id)}>
                        <FiEdit size="25" color="blue"/>
                    </button>
                    <button type="button" onClick={() => deletePontoTuristico(pontoTuristico.id)}>
                        <AiOutlineDelete size="25" color="red"/>
                    </button>
                    </li>
                ))}
            </ul>
            )}
            <Pagination limit={5} setOffset={setOffset} offset={offset} total={pontosTuristicos.length} />
                
         </div>
        
     )
}