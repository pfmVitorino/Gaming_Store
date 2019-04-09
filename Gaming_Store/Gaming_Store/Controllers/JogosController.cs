using Gaming_Store.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Gaming_Store.Controllers
{
    public class JogosController : Controller
    {
        private JogosDB db = new JogosDB();

        // GET: Jogos
        /// <summary>
        /// lista todos os jogos
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //db.Jogos.ToList() em SQL SELECT * FROM Jogos;
            //enviar para a view uma lista com todos os jogos da base de dados
            return View(db.Jogos.ToList().OrderBy(a => a.Nome));
        }

        public ActionResult AdminView()
        {
            //db.Jogos.ToList() em SQL SELECT * FROM Jogos;
            //enviar para a view uma lista com todos os jogos da base de dados
            return View(db.Jogos.ToList().OrderBy(a => a.Nome));
        }

        public ActionResult List()
        {
            //db.Jogos.ToList() em SQL SELECT * FROM Jogos;
            //enviar para a view uma lista com todos os jogos da base de dados
            return View(db.Jogos.ToList().OrderBy(a => a.Nome));
        }

        // GET: Jogos/Details/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public ActionResult Details(int? id)
        {
            //proteção para o caso de não ter sido fornecido um id
            if (id == null)
            {
                //devolve um erro que não existe o id
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return RedirectToAction("Index");
            }
            //procura na BD, o jogo cujo ID foi fornecido

            Jogos Jogo = db.Jogos.Find(id);
            //proteção para o caso de não ter sido encontrado qualquer jogo
            //que tenha o ID fornecido
            if (Jogo == null)
            {
                //jogo não encontrado
                //return HttpNotFound();
                return RedirectToAction("Index");
            }
            return View(Jogo);
        }
        // GET: Jogos/ListaJogos/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

       

        // GET: Jogos/Create
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            //apresenta a view para se inserir num Jogo
            return View();
        }

        // POST: Jogos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nome,Preco")] Jogos Jogo, HttpPostedFileBase uploadFotografia)
        {
            //Escreve a fotografia que foi carregada - O save é efetuado na pasta das imagens do disco rigido
            //Especificar id do Jogo
            //testar se há registos na tabela dos jogos

           

            int idNew = 0;
            try
            {
                idNew = db.Jogos.Max(a => a.Id) + 1;
            }
            catch (Exception)
            {

                idNew = 1;

            }




            //guardar id do novo jogo
            Jogo.Id = idNew;
            //escolher nome do ficheio
            string nomeImagem = "Jogo_" + idNew + ".jpg";
            string path = "";
            //carregar nome do ficheiro
            if (uploadFotografia != null)
            {
                //formatar tamanho da imagem 

                //Criar caminho para guardar o ficheiro
                path = Path.Combine(Server.MapPath("~/imagens/"), nomeImagem);
                //guardar nome do ficheiro
                Jogo.Fotografia = nomeImagem;
            }
            else
            {
                ModelState.AddModelError("", "Tem  de por uma imagem...");
                return View(Jogo);
            }


            //ModelState.IsValid confronta os dados fornecidos na view
            if (ModelState.IsValid)
            {
                try
                {
                    db.Jogos.Add(Jogo);
                    db.SaveChanges();
                    //escreve os detalhes de um novo jogo na DB
                    uploadFotografia.SaveAs(path);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError("", "Houve um erro com a criação do novo Jogo...");

                    /// se existir uma classe chamada "Erro.cs"
                    /// iremos nela registar os dados do erro
                    /// - criar um obejcto desta classe
                    /// - atribuir a esse objecto os dados do erro
                    ///   - nome do controller
                    ///   - nome do método
                    ///   - hora + data do erro
                    ///   - mensagem do erro (ex)
                    ///   - dados que se tentavam inserir
                    ///   - outros dados considerados relevantes
                    /// - guardar o objecto na Base de Dados
                    ///  - notificar um gestor do sistema, por email,
                    ///  ou por outro meio, da ocorrência do erro e dos seus dados



                }
            }
            return View(Jogo);
        }

        // GET: Jogos/Edit/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogos Jogo = db.Jogos.Find(id);
            if (Jogo == null)
            {
                return HttpNotFound();
            }
            return View(Jogo);
        }

        // POST: Jogos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Jogo"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Preco,Fotografia")] Jogos Jogo)
        {
            if (ModelState.IsValid)
            {
                //neste caso já existe jogo
                //apenas quero editar os seus detalhes
                db.Entry(Jogo).State = EntityState.Modified;
                //faz o commit
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Jogo);
        }

        // GET: Jogos/Delete/5
        /// <summary>
        /// apresenta na view os dados de um jogo com vista á sua eventual
        /// eliminação
        /// 
        /// </summary>
        /// <param name="id">identificador do jogo a apagar</param>
        /// <returns></returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogos Jogo= db.Jogos.Find(id);
            if (Jogo == null)
            {
                return HttpNotFound();
            }
            return View(Jogo);
        }

        // POST: Jogos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jogos Jogo = db.Jogos.Find(id);
            try
            {


                //remove o jogo
                db.Jogos.Remove(Jogo);
                //commit
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", string.Format("Não é possível eliminação do Jogo ", id, Jogo.Nome)
                    );


            }
            // se cheguei aqui é pq houve um problema 
            // devolver os dados do jogo á view

            return View(Jogo);


        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
