using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Red.Application.Interfaces;
using Red.Application.ViewModel;
using Red.Library;

namespace Red.Web.Controllers
{
    public class TurmaController : BaseController
    {
        #region Vars

        private readonly ITurmaServiceApp turmaAppService;
        private readonly IEvangelizadorServiceApp evangelizadorAppService;

        #endregion

        #region Ctor

        public TurmaController(ITurmaServiceApp turmaAppService, 
                               IEvangelizadorServiceApp evangelizadorAppService)
        {
            this.turmaAppService = turmaAppService;
            this.evangelizadorAppService = evangelizadorAppService;
        }

        #endregion

        #region Public Methods
        public ActionResult Index()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Turmas Moral Cristã",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Turmas Moral Cristã", ActionName = "Index", ControllerName = "Turma"},
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            ViewBag.Evangelizador = ObterEvangelizadores();

            return View();
        }

        public ActionResult CopiarTurma()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Copiar Turmas Moral Cristã",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Turmas Moral Cristã", ActionName = "Index", ControllerName = "Turma"},
                 new BreadCrumb {LinkText = "Copiar Turmas Moral Cristã", ActionName = "CopiarTurma", ControllerName = "Turma"},
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            ViewBag.Evangelizador = ObterEvangelizadores();

            return View();
        }

        public ActionResult Edit(int id)
        {
            var turma = turmaAppService.ObterPorId(id);
            return Json(turma, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Gravar(string nome, int ano, int evangelizador)
        {
            var gravarResult = turmaAppService.Gravar(nome, ano, evangelizador);
            object retorno;
            if (gravarResult.IsValid)
            {
                retorno = new
                {
                    Mensagem = "Registro Gravado com Sucesso",
                    Erro = false
                };
            }
            else
            {
                retorno = new
                {
                    Mensagem = RenderizeErros(gravarResult),
                    Erro = true
                };
            }

            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ExecutaCopia(int turma, int ano, string nome)
        {
            var gravarResult = turmaAppService.CopiarTurma(turma, ano, nome);
            object retorno;
            if (gravarResult.IsValid)
            {
                retorno = new
                {
                    Mensagem = "Registro Gravado com Sucesso",
                    Erro = false
                };
            }
            else
            {
                retorno = new
                {
                    Mensagem = RenderizeErros(gravarResult),
                    Erro = true
                };
            }

            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AdicionarAlunos(int turma, string alunos)
        {
            var gravarResult = turmaAppService.AdicionarAlunos(turma, alunos);
            object retorno;
            if (gravarResult.IsValid)
            {
                retorno = new
                {
                    Mensagem = "Registro Gravado com Sucesso",
                    Erro = false
                };
            }
            else
            {
                retorno = new
                {
                    Mensagem = RenderizeErros(gravarResult),
                    Erro = true
                };
            }

            return Json(retorno, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Atualizar(int turma, string nome)
        {
            var gravarResult = turmaAppService.Atualizar(turma, nome);
            object retorno;
            if (gravarResult.IsValid)
            {
                retorno = new
                {
                    Mensagem = "Registro Gravado com Sucesso",
                    Erro = false
                };
            }
            else
            {
                retorno = new
                {
                    Mensagem = RenderizeErros(gravarResult),
                    Erro = true
                };
            }

            return Json(retorno, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Excluir(int id)
        {
            var excluirResult = turmaAppService.Excluir(id);

            object retorno;
            if (excluirResult.IsValid)
            {
                retorno = new
                {
                    Mensagem = "Registro Excluído com Sucesso",
                    Erro = false
                };
            }
            else
            {
                retorno = new
                {
                    Mensagem = RenderizeErros(excluirResult),
                    Erro = true
                };
            }

            return Json(retorno, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ExcluirAluno(int turma, int aluno)
        {
            var excluirResult = turmaAppService.ExcluirAluno(turma, aluno);

            object retorno;
            if (excluirResult.IsValid)
            {
                retorno = new
                {
                    Mensagem = "Registro Excluído com Sucesso",
                    Erro = false
                };
            }
            else
            {
                retorno = new
                {
                    Mensagem = RenderizeErros(excluirResult),
                    Erro = true
                };
            }

            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Turmas(int id)
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Atividade Prefererida",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Atividade Prefererida", ActionName = "Index", ControllerName = "AtividadePrefererida"},
                 new BreadCrumb {LinkText = "Alunos", ActionName = "Index", ControllerName = "Alunos"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion
            var evangelizador = evangelizadorAppService.ObterPorId(id);

            ViewBag.Ano = ObterAno(evangelizador.Turmas);
            ViewBag.Evangelizador = evangelizador.Nome;
            ViewBag.EvangelizadorId = evangelizador.Codigo;

            return View("Turmas");
        }

        [HttpGet]
        public ActionResult ObterAlunos(int idEvangelizador, int ano)
        {
            var alunos = turmaAppService.ObterPorEvangelizador(idEvangelizador, ano);

            return View("TurmasLista", alunos);
        }

        [HttpGet]
        public ActionResult ObterTurma(int idEvangelizador, int ano)
        {
            var turma = turmaAppService.ObterTurma(idEvangelizador, ano);

            if (turma == null)
            {
                turma = new TurmaViewModel();
            }
            else
            {
                //só quero a turma mesmo
                turma.Alunos.Clear();
                turma.Evangelizador.Turmas.Clear();
            }

            return Json(turma, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult ObterAlunosTurma(int idEvangelizador, int ano)
        {
            var alunos = turmaAppService.ObterPorEvangelizador(idEvangelizador, ano);

            return View("ListaAlunos", alunos);
        }

        [HttpGet]
        public ActionResult ObterAlunosLivres(int ano)
        {
            var alunos = turmaAppService.ObterAlunosLivres(ano);

            return View("AlunosLivresLista", alunos);
        }

        #endregion

        private SelectList ObterAno(IList<TurmaViewModel> turmas)
        {

            var anoList = new SelectList(turmas.OrderBy(t => t.Ano), "Ano", "Ano");

            return anoList;
        }

        private SelectList ObterEvangelizadores()
        {

            var evangelizadores = evangelizadorAppService.ObterTodos();
            var evangelizadoresList = new SelectList(evangelizadores.OrderBy(t => t.Nome), "Codigo", "Nome");

            return evangelizadoresList;
        }

    }
}