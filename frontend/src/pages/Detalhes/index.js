import React, {useState, useEffect} from "react";
import {Link, useHistory, useParams} from 'react-router-dom';
import './styles.css';
import 'bootstrap/dist/css/bootstrap.min.css';

import api from "../../services/api";

import logo from '../../assets/viagem.png';

export default function PontoTuristico(){

    const [id,setId]= useState(null);
    const [nome,setNome]= useState('');
    const [descricao,setDescricao]= useState('');
    const [localizacao,setLocalizacao]= useState('');
    const [cidade,setCidade]= useState('');
    const [estado,setEstado]= useState('');
    
    const {pontoTuristicoId} = useParams();
    const history = useHistory();

    useEffect(()=>{
        if(pontoTuristicoId === '0')
            return;
        else loadPontoTuristico();
    }, pontoTuristicoId)
    
    async function loadPontoTuristico(){
        try{
            const response = await api.get(`/PontosTuristicos/${pontoTuristicoId}`);
            setId(response.data.id);
            setNome(response.data.nome);
            setDescricao(response.data.descricao);
            setLocalizacao(response.data.localizacao);
            setCidade(response.data.cidade);
            setEstado(response.data.estado);
        }catch(error){
            alert('Erro ao recuperar o ponto turístico ' + error);
            history.push('/');
        }
    }

     return(
         <div className="lerpontoTuristico-container">
             <header>
                <img src={logo} alt="logo" />
                <h1>Detalhes do Ponto Turístico Selecionado</h1>
             </header>
             <br />
             <br />
            <ul>
                
                    <li key={pontoTuristico.id}>
                        {pontoTuristico.nome}<br /><br />
                        {pontoTuristico.descricao}<br /><br />                
                    </li>
            </ul>
         </div>
        
     )
}