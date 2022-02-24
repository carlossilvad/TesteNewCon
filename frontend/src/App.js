import React, {useState, useEffect} from 'react';
import './App.css';

import 'bootstrap/dist/css/bootstrap.min.css';
import axios from 'axios';
import {Modal, ModalBody, ModalFooter, ModalHeader} from 'reactstrap';
import logo from './assets/viagem.png';

function App() {

  const baseUrl="https://localhost:44327/api/pontosturisticos";

  const [data, setData]=useState([]);
  const [updateData, setUpdateData] = useState(true);

  const [modalAdicionar, setModalAdicionar]=useState(false);
  const [modalEditar, setModalEditar]=useState(false);
  const [modalExcluir, setModalExcluir]=useState(false);

  const [pontoTuristicoSelecionado, setPontoTuristicoSelecionado]=useState({
    id: '',
    nome: '',
    descricao: '',
    localizacao: '',
    cidade: '',
    estado: ''
  })

  const selecionarPontoTuristico = (pontoTuristico, opcao) => {
    setPontoTuristicoSelecionado(pontoTuristico);
    (opcao === "Editar") ?
     abrirFecharModalEditar(): abrirFecharModalExcluir();
  }

  const abrirFecharModalAdicionar=()=>{
    setModalAdicionar(!modalAdicionar)
  }

  const abrirFecharModalEditar=()=>{
    setModalEditar(!modalEditar);
  }

  const abrirFecharModalExcluir=()=>{
    setModalExcluir(!modalExcluir);
  }
  
  const handleChange=e=>{
    const {name, value}=e.target;
    setPontoTuristicoSelecionado({
      ...pontoTuristicoSelecionado,
      [name]: value
    });
    console.log(pontoTuristicoSelecionado);
  }

  const pedidoGet = async()=>{
    await axios.get(baseUrl)
    .then(response => {
      setData(response.data);
    }).cath(error=>{
      console.log(error);
    })
  }

  const pedidoPost= async()=>{
    delete pontoTuristicoSelecionado.id;
    await axios.post(baseUrl, pontoTuristicoSelecionado)
    .then(response=>{
      setData(data.concat(response.data));
      setUpdateData(true);
      abrirFecharModalAdicionar();
    }).cath(error=>{
      console.log(error);
    })
  }

  const pedidoPut= async()=>{
    await axios.put(baseUrl+"/"+pontoTuristicoSelecionado.id, pontoTuristicoSelecionado)
    .then(response=>{
      var resposta=response.data;
      var dadosAuxiliar=data;
      dadosAuxiliar.map(pontoTuristico=>{
        if(pontoTuristico.id===pontoTuristicoSelecionado.id){
          pontoTuristico.nome=resposta.nome;
          pontoTuristico.descricao=resposta.descricao;
          pontoTuristico.localizacao=resposta.localizacao;
          pontoTuristico.cidade=resposta.cidade;
          pontoTuristico.estado=resposta.estado;
        }
      });
      setUpdateData(true);
      abrirFecharModalEditar();
    }).cath(error=>{
      console.log(error);
    })
  }

  const pedidoDelete= async()=>{
    await axios.delete(baseUrl+"/"+pontoTuristicoSelecionado.id)
    .then(response=>{
      setData(data.filter(pontoTuristico => pontoTuristico.id !== response.data));
      setUpdateData(true);
      abrirFecharModalExcluir();
    }).cath(error=>{
      console.log(error);
    })
  }



  useEffect(()=>{
    if(updateData){
       pedidoGet();
       setUpdateData(false);
    }
  },[updateData])

  return (
    <div className="pontoTuristico-container">
      <br />
      <h3>Cadastro de Pontos Turísticos</h3>
      <header>
          <img src={logo} alt='Cadastro' />
          <button className="btn btn-success" onClick={()=>abrirFecharModalAdicionar()}>Adicionar Ponto Turístico</button>
      </header>
      <br />
      <table className="table table-hover table-bordered">
        <thead>
        <tr>
          <th>Id</th>
          <th>Nome</th>
          <th>Descricao</th>
          <th>Localizacao</th>
          <th>Cidade</th>
          <th>Estado</th>
        </tr>
        </thead>
        <tbody>
          {data.map(pontoTuristico=>(
            <tr key={pontoTuristico.id}>
              <td>{pontoTuristico.id}</td>
              <td>{pontoTuristico.nome}</td>
              <td>{pontoTuristico.descricao}</td>
              <td>{pontoTuristico.localizacao}</td>
              <td>{pontoTuristico.cidade}</td>
              <td>{pontoTuristico.estado}</td>
              <td>
                <button className="btn btn-primary" onClick={()=>selecionarPontoTuristico(pontoTuristico, "Editar")}>Editar</button> {"  "}
                <button className="btn btn-danger" onClick={()=>selecionarPontoTuristico(pontoTuristico, "Excluir")}>Excluir</button>
              </td>
            </tr>
          ))}
        </tbody>
    </table>

    <Modal isOpen={modalAdicionar}>
  
    <ModalHeader>Adicionar Pontos Turísticos</ModalHeader>

    <ModalBody>

      <div className="form-group">
        <label>Nome: </label>
        <br />
        <input type="text" className="form-control" name="nome" onChange={handleChange} />
        <br />
        <label>Descricao: </label>
        <br />
        <input type="text" className="form-control" name="descricao" onChange={handleChange}/>
        <br />
        <label>Localizacao: </label>
        <br />
        <input type="text" className="form-control" name="localizacao" onChange={handleChange} />
        <br />
        <label>Cidade: </label>
        <br />
        <input type="text" className="form-control" name="cidade" onChange={handleChange} />
        <br />
        <label>Estado: </label>
        <br />
        <input type="text" className="form-control" name="estado" onChange={handleChange} />
        <br />
      </div>

    </ModalBody>

    <ModalFooter>
      <button className="btn btn-primary" onClick={()=>pedidoPost()}>Adicionar</button>{"   "}
      <button className="btn btn-danger" onClick={()=>abrirFecharModalAdicionar()}>Cancelar</button>
    </ModalFooter>

    </Modal>

  <Modal isOpen={modalEditar}>
  
  <ModalHeader>Editar Ponto Turístico</ModalHeader>

  <ModalBody>

    <div className="form-group">
    <label>ID: </label><br />
    <input type="text" className="form-control" readOnly value={pontoTuristicoSelecionado && pontoTuristicoSelecionado.id}/><br />
      <label>Nome: </label>
      <br />
      <input type="text" className="form-control" name="nome" onChange={handleChange}
             value={pontoTuristicoSelecionado && pontoTuristicoSelecionado.nome}/>
      <br />
      <label>Descricao: </label>
      <br />
      <input type="text" className="form-control" name="descricao" onChange={handleChange}
             value={pontoTuristicoSelecionado && pontoTuristicoSelecionado.descricao}/>
      <br />
      <label>Localizacao: </label>
      <br />
      <input type="text" className="form-control" name="localizacao" onChange={handleChange}
             value={pontoTuristicoSelecionado && pontoTuristicoSelecionado.localizacao}/>
      <br />
      <label>Cidade: </label>
      <br />
      <input type="text" className="form-control" name="cidade" onChange={handleChange}
             value={pontoTuristicoSelecionado && pontoTuristicoSelecionado.cidade}/>
      <br />
      <label>Estado: </label>
      <br />
      <input type="text" className="form-control" name="estado" onChange={handleChange}
             value={pontoTuristicoSelecionado && pontoTuristicoSelecionado.estado}/>
      <br />
    </div>

  </ModalBody>

  <ModalFooter>
    <button className="btn btn-primary" onClick={()=>pedidoPut()}>Editar</button>{"   "}
    <button className="btn btn-danger" onClick={()=>abrirFecharModalEditar()}>Cancelar</button>
  </ModalFooter>

  </Modal>

  <Modal isOpen={modalExcluir}>
  
  <ModalHeader>Excluir Ponto Turístico</ModalHeader>

  <ModalBody>
      Tem certeza que deseja excluir o Ponto Turístico "{pontoTuristicoSelecionado && pontoTuristicoSelecionado.nome}"?
  </ModalBody>

  <ModalFooter>
    <button className="btn btn-danger" onClick={()=>pedidoDelete()}>Sim, excluir</button>{"   "}
    <button className="btn btn-secondary" onClick={()=>abrirFecharModalExcluir()}>Não excluir</button>
  </ModalFooter>

  </Modal>

    </div>
  );
}

export default App;
