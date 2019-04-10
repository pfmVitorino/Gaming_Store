using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gaming_Store.Models;

namespace Gaming_Store.Controllers
{
    public class JogosController : Controller
    {
        private JogosDB db = new JogosDB();

        // GET: Jogos
        public ActionResult Index()
        {
            return View(db.Jogos.ToList());
        }

        // GET: Jogos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogos jogos = db.Jogos.Find(id);
            if (jogos == null)
            {
                return HttpNotFound();
            }
            return View(jogos);
        }

        // GET: Jogos/Create
        public ActionResult Create()
        {
            ViewBag.Plataformas = db.Plataformas;
            return View();
        }

        // POST: Jogos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fotografia,Nome,Preco,Plataforma")] Jogos jogos, HttpPostedFileBase uploadFotografia)
        {

            //Escreve a fotografia que foi carregada - O save é efetuado na pasta das imagens do disco rigido
            //Especificar id do jogo
            //testar se há registos na tabela dos jogos

            //if (db.Jogos.Count() != 0) { }

            //ou então, usar a instrução testar TRY/CATCH

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
            jogos.Id = idNew;
            //escolher nome do ficheio
            string nomeImagem = "Jogo_" + idNew + ".jpg";
            string path = "";
            //carregar nome do ficheiro
            if (uploadFotografia != null)
            {
                //formatar tamanho da imagem 

                //Criar caminho para guardar o ficheiro
                path = Path.Combine(Server.MapPath("~/Fotografias/"), nomeImagem);
                //guardar nome do ficheiro
                jogos.Fotografia = nomeImagem;
            }
            else
            {
                ModelState.AddModelError("", "Tem  de por uma imagem...");
                ViewBag.Plataformas = db.Plataformas;
                return View(jogos);
            }


            //ModelState.IsValid confronta os dados fornecidos na view
            if (ModelState.IsValid)
            {
                try
                {
                    db.Jogos.Add(jogos);
                    db.SaveChanges();
                    //escreve os dados de um novo jogo na DB
                    uploadFotografia.SaveAs(path);
                    ViewBag.Plataformas = db.Plataformas;
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError("", "Houve um erro com a criação do novo Jogo...");
                }
            }
             ViewBag.Plataformas = db.Plataformas;
            return View(jogos);
        }

        // GET: Jogos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogos jogos = db.Jogos.Find(id);
            if (jogos == null)
            {
                return HttpNotFound();
            }
            ViewBag.Plataformas = db.Plataformas;
            return View(jogos);
        }

        // POST: Jogos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Preço,Fotografia,Plataforma")] Jogos jogos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jogos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Plataformas = db.Plataformas;
            return View(jogos);
        }

        // GET: Jogos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogos jogos = db.Jogos.Find(id);
            if (jogos == null)
            {
                return HttpNotFound();
            }
            ViewBag.Plataformas = db.Plataformas;
            return View(jogos);
        }

        // POST: Jogos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jogos jogos = db.Jogos.Find(id);
            db.Jogos.Remove(jogos);
            db.SaveChanges();
            return RedirectToAction("Index");
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
