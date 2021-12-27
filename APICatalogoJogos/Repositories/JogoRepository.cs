using APICatalogoJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalogoJogos.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private static Dictionary<Guid, Jogo> jogos = new Dictionary<Guid, Jogo>()
        {
            {Guid.Parse("29a7f8a3-0d52-452e-820d-66b989a9036e"), new Jogo{ Id = Guid.Parse("29a7f8a3-0d52-452e-820d-66b989a9036e"), Nome = "Fifa 21", Produtora = "EA Sports", Preco = 200} },
            {Guid.Parse("4b1138e4-5866-4825-bfb1-6bf85607e6ca"), new Jogo{ Id = Guid.Parse("4b1138e4-5866-4825-bfb1-6bf85607e6ca"), Nome = "Fifa 20", Produtora = "EA Sports", Preco = 190} },
            {Guid.Parse("1091436c-5e56-4387-a8b9-df55c480e0b8"), new Jogo{ Id = Guid.Parse("1091436c-5e56-4387-a8b9-df55c480e0b8"), Nome = "Fifa 19", Produtora = "EA Sports", Preco = 180} },
            {Guid.Parse("57bb5341-ce08-4bd1-853a-b18b65d668a1"), new Jogo{ Id = Guid.Parse("57bb5341-ce08-4bd1-853a-b18b65d668a1"), Nome = "Fifa 18", Produtora = "EA Sports", Preco = 170} },
            {Guid.Parse("9c4553bf-f189-42e7-a154-23f5e1d0a832"), new Jogo{ Id = Guid.Parse("9c4553bf-f189-42e7-a154-23f5e1d0a832"), Nome = "Street Fighter V", Produtora = "Capcom", Preco = 80} },
            {Guid.Parse("c68e9dbe-3c47-47b3-8efd-efb0b95439d7"), new Jogo{ Id = Guid.Parse("c68e9dbe-3c47-47b3-8efd-efb0b95439d7"), Nome = "Grand Theft Auto V", Produtora = "Rockstar", Preco = 190} },
        };

        public Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Jogo> Obter(Guid id)
        {
            if (!jogos.ContainsKey(id))
                return null;

            return Task.FromResult(jogos[id]);
        }

        public Task<List<Jogo>> Obter(string nome, string produtora)
        {
            return Task.FromResult(jogos.Values.Where(jogo => jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora)).ToList());
        }
        
        public Task<List<Jogo>> ObterSemLambda(string nome, string produtora)
        {
            var retorno = new List<Jogo>();

            foreach (var jogo in jogos.Values)
            {
                if (jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora))
                    retorno.Add(jogo);
            }

            return Task.FromResult(retorno);
        }

        public Task Inserir(Jogo jogo)
        {
            jogos.Add(jogo.Id, jogo);
            return Task.CompletedTask;
        }

        public Task Atualizar(Jogo jogo)
        {
            jogos[jogo.Id] = jogo;
            return Task.CompletedTask;
        }

        public Task Remover(Guid id)
        {
            jogos.Remove(id);
            return Task.CompletedTask;
        }


        public void Dispose()
        {
            // Fecha a conexão com o banco de dados
        }
    }
}
