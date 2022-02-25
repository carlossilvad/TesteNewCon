import React from "react";
import {BrowserRouter, Route, Switch } from 'react-router-dom';
import PontosTuristicos from "../pages/Pontos Turisticos";
import NovoPontoTuristico from "../pages/Novo Ponto Turistico";
import PontoTuristico from "../pages/Detalhes";

export default function Routes(){
    return (
        <BrowserRouter>
            <Switch>
                <Route path="/" exact component={PontosTuristicos}/>
                <Route path="/pontoTuristico/novo/:pontoTuristicoId" component={NovoPontoTuristico}/>
                <Route path="/pontoTuristico" component={PontoTuristico}/>
            </Switch>
        </BrowserRouter>
    );
}