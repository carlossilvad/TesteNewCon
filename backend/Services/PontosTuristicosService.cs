using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;
using backend.Repositories.Interface;
using backend.Services.Interfaces;
using backend.Services.Pagination;

namespace backend.Services
{
    public class PontosTuristicosService : IPontoTuristicoService
    {
        private readonly IPontoTuristicoRepository _pontoTuristicoRepository;

        public PontosTuristicosService(IPontoTuristicoRepository pontoTuristicoRepository)
        {
            _pontoTuristicoRepository = pontoTuristicoRepository;
        }

        public PagedList<PontoTuristico> ObterPontosTuristicos(PontoTuristicoParameters pontosTuristicosParameters)
        {
            return _pontoTuristicoRepository.GetPontosTuristicos(pontosTuristicosParameters);
        }

        public async Task<List<PontoTuristico>> ObterPontosTuristicosPorLocalizacao(string localizacao)
        {
            var pontoTuristico = await _pontoTuristicoRepository.GetPontosTuristicosPorNome(localizacao);

            return pontoTuristico;
        }

        public async Task<List<PontoTuristico>> ObterPontosTuristicosPorNome(string nome)
        {
            var pontoTuristico = await _pontoTuristicoRepository.GetPontosTuristicosPorNome(nome);

            return pontoTuristico;
        }

        public async Task<PontoTuristico> ObterPontoTuristicoPorId(int id)
        {
            var pontoTuristico = await _pontoTuristicoRepository.ObterPorId(id);

            return pontoTuristico;
        }

        public async Task<PontoTuristico> CriarPontoTuristico(PontoTuristico pontoTuristico)
        {
            var pontoTuristicoNovo = await _pontoTuristicoRepository.Criar(pontoTuristico);

            return pontoTuristicoNovo;
        }
        
        public async Task<PontoTuristico> AtualizarPontoTuristico(int id, PontoTuristico pontoTuristico)
        {
            var ponto = await _pontoTuristicoRepository.ObterPorId(id);

            if(ponto.Equals(null))
            throw new Exception("Não existe ponto turistico com o id informado.");

            var pontoAtualizado = await _pontoTuristicoRepository.Atualizar(pontoTuristico);

            return pontoAtualizado;
        }

        public async Task DeletarPontoTuristico(int id)
        {
            await _pontoTuristicoRepository.Deletar(id);
        }

    }
}