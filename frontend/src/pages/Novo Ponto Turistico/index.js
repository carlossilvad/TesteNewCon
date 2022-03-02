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
        <div className="novo-pontoTuristico-container container">
            <div className="content"><br />
                <section className="form">
                <h1>{pontoTuristicoId === '0'? 'Adicionar Ponto Turístico' : 'Atualizar Ponto Turístico'}</h1>
                <Link className="back-link" to="/">
                    <FiCornerDownLeft size="25"/>
                    Voltar
                </Link>
                </section>
                <br />
                <form onSubmit={saveOrUpdate}>
                <div class="form-group">
                <label>Nome</label>
                <input type="text" class="form-control"  placeholder="Nome do Ponto Turístico..."
                value={nome}
                onChange= {e=> setNome(e.target.value)}
                />
                </div>
                <br />
                <div class="form-group">
                <label>Localização</label>
                <input type="text" class="form-control"  placeholder="Localização/Referência do Ponto Turístico..."
                value={localizacao}
                onChange= {e=> setLocalizacao(e.target.value)}
                />
                </div>
                <br />
                <div class="row">
                    <div class="form-group col-4">
                    <label>Estado</label>
                    <select id="inputState" class="form-control" value={estado}
                        onChange= {e=> setEstado(e.target.value)}>
                        <option selected>Selecione...</option>
                        <option>AC</option>
                        <option>AL</option>
                        <option>AP</option>
                        <option>AM</option>
                        <option>BA</option>
                        <option>CE</option>
                        <option>DF</option>
                        <option>ES</option>
                        <option>GO</option>
                        <option>MA</option>
                        <option>MT</option>
                        <option>MS</option>
                        <option>MG</option>
                        <option>PA</option>
                        <option>PB</option>
                        <option>PR</option>
                        <option>PE</option>
                        <option>PI</option>
                        <option>RJ</option>
                        <option>RN</option>
                        <option>RS</option>
                        <option>RO</option>
                        <option>RR</option>
                        <option>SC</option>
                        <option>SP</option>
                        <option>SE</option>
                        <option>TO</option>
                    </select>
                    </div>
                    <div class="form-group col-8">
                    <label>Cidade</label>
                    <input type="text" class="form-control"  placeholder="Cidade..."
                    value={cidade}
                    onChange= {e=> setCidade(e.target.value)}
                    />
                    </div>
                </div>
                <br />
                <div class="form-group">
                <label>Descrição</label>
                <input type="text" class="form-control"  placeholder="Descrição do Ponto Turístico..."
                value={descricao}
                onChange= {e=> setDescricao(e.target.value)}
                />
                </div>
                <br />
                <button className="btn btn-primary" type="submit">{pontoTuristicoId === '0'? 'Adicionar' : 'Atualizar'}</button>
                </form>
            </div>
        </div>
    );
}