import React, { useEffect, useState } from "react";
import {Link, useHistory, useParams} from 'react-router-dom';
import './styles.css';
import api from "../../services/api";

import {FiCornerDownLeft, FiMapPin} from 'react-icons/fi';

export default function NovoPontoTuristico(){

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

    async function saveOrUpdate(event){
        event.preventDefault();

        const data = {
            nome,
            descricao,
            localizacao,
            cidade,
            estado
        }

        try{
          if(pontoTuristicoId === '0'){
            await api.post('/PontosTuristicos',data);
            }
            else{
                data.id = id;
                await api.put(`/PontosTuristicos/${id}`,data)
            }

        }catch(error){
            alert('Erro ao adicionar ponto turístico ' + error);
        } history.push('/');
    }


    return(
        <div className="novo-pontoTuristico-container">
            <div className="content">
                <section className="form">
                <FiMapPin size="105"/>
                <h1>{pontoTuristicoId === '0'? 'Adicionar Ponto Turístico' : 'Atualizar Ponto Turístico'}</h1>
                <Link className="back-link" to="/">
                    <FiCornerDownLeft size="25"/>
                    Voltar
                </Link>
                </section>
                <form onSubmit={saveOrUpdate}>
                    <input placeholder="Nome"
                        value={nome}
                        onChange= {e=> setNome(e.target.value)}
                    />
                    <input placeholder="Descrição"
                        value={descricao}
                        onChange= {e=> setDescricao(e.target.value)}
                    />
                    <input placeholder="Localização/Referência"
                        value={localizacao}
                        onChange= {e=> setLocalizacao(e.target.value)}
                    />
                    <input placeholder="Cidade"
                        value={cidade}
                        onChange= {e=> setCidade(e.target.value)}
                    />
                    <input placeholder="Estado"
                        value={estado}
                        onChange= {e=> setEstado(e.target.value)}
                    />
                    <button className="btn btn-primary" type="submit">{pontoTuristicoId === '0'? 'Adicionar' : 'Atualizar'}</button>
                </form>
            </div>
        </div>
    );
}