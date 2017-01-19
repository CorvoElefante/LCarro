using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Xamarin.Forms;
using System.Collections.Generic;
using SQLite.Net.Interop;
namespace Carro
{
    class AcessoDados : IDisposable
    {
        private SQLite.Net.SQLiteConnection _conexao;

        public AcessoDados()
        {
            var config = DependencyService.Get<IConfig>();
            _conexao = new SQLite.Net.SQLiteConnection(config.Plataforma, System.IO.Path.Combine(config.DiretorioDB, "bancodados.db3"));

            _conexao.CreateTable<Pessoa>();

        }

        public void Insert(Pessoa pessoa)
        {
            _conexao.Insert(pessoa);
        }

        public void Update(Pessoa pessoa)
        {
            _conexao.Update(pessoa);
        }

        public void Delete(Pessoa pessoa)
        {
            _conexao.Delete(pessoa);
        }

        public Pessoa ObterPorId(int id)
        {
            return _conexao.Table<Pessoa>().FirstOrDefault(c => c.Id == id);
        }

        public List<Pessoa> Listar()
        {
            List<Pessoa> pessoa = _conexao.Table<Pessoa>().ToList();
            return pessoa;
        }

        public void Dispose()
        {
            _conexao.Dispose();
        }
    }
}
