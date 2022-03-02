import { useState } from "react";

interface Ponto {
    id: number;
    nome: string;
    descricao: string;
    localizacao: string;
    cidade: string;
    estado: string;
}

export default function UsePontos (pageLimit: 3){
    const [pontos, setPontos] = useState<Ponto[]>([])

    function fetchPontos (page: number){
        const virtualPage = ((page - 1) * pageLimit) <= 0
        ? 0
        : ((page - 1) * pageLimit)
        fech(
            `https://localhost:44327/api/pontosturisticos?_start=${virtualPage}&_limit=${pageLimit}`
        )
        .then(res => res.json())
        .then(setPontos)
        .cath(window.alert)
    }

    return {
        fetchPontos,
        pontos
    }
}