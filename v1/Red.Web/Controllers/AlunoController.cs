using Red.Application.Interfaces;
using Red.Application.ViewModel;
using Red.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace Red.Web.Controllers
{
    public class AlunoController : BaseController
    {
        #region Vars

        private readonly IAlunoServiceApp alunoAppService;
        private readonly IResponsavelServiceApp responsavelAppService;
        private readonly IStatusServiceApp statusAppService;

        #endregion

        #region Ctor

        public AlunoController(IAlunoServiceApp alunoAppService,
                               IResponsavelServiceApp responsavelAppService,
                               IStatusServiceApp statusAppService)
        {
            this.alunoAppService = alunoAppService;
            this.responsavelAppService = responsavelAppService;
            this.statusAppService = statusAppService;
        }

        #endregion

        #region Public Methods
        public ActionResult Index()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Alunos",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Alunos", ActionName = "Index", ControllerName = "Aluno"},
                 new BreadCrumb {LinkText = "Lista", ActionName = "Index", ControllerName = "Aluno"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            ViewBag.Status = ObterListaStatusParaCombo();
            ViewBag.Responsavel = ObterListaResponsavelParaCombo();

            var listaAlunos = alunoAppService.ObterTodos();
            return View(listaAlunos);
        }

        [Route("Aluno/Ativos/")]
        public ActionResult Ativos()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Alunos Ativos",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Alunos", ActionName = "Index", ControllerName = "Aluno"},
                 new BreadCrumb {LinkText = "Lista", ActionName = "Ativos", ControllerName = "Aluno"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            ViewBag.Status = ObterListaStatusParaCombo();
            ViewBag.Responsavel = ObterListaResponsavelParaCombo();

            var listaAlunos = alunoAppService.ObterTodosAtivos();
            return View("Index", listaAlunos);
        }

        [Route("Aluno/NaoAtivos/")]
        public ActionResult NaoAtivos()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Alunos Não Ativos",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Alunos", ActionName = "Index", ControllerName = "Aluno"},
                 new BreadCrumb {LinkText = "Lista", ActionName = "NaoAtivos", ControllerName = "Aluno"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            ViewBag.Status = ObterListaStatusParaCombo();
            ViewBag.Responsavel = ObterListaResponsavelParaCombo();

            var listaAlunos = alunoAppService.ObterTodosNaoAtivos();
            return View("Index", listaAlunos);
        }

        public ActionResult Alunos(IList<AlunoViewModel> listaAlunos)
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Alunos",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Alunos", ActionName = "Index", ControllerName = "Aluno"},
                 new BreadCrumb {LinkText = "Lista", ActionName = "Index", ControllerName = "Aluno"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            ViewBag.Status = ObterListaStatusParaCombo();
            ViewBag.Responsavel = ObterListaResponsavelParaCombo();

            if (listaAlunos == null)
            {
                listaAlunos = (List<AlunoViewModel>)TempData["Alunos"];
            }
            TempData["Alunos"] = listaAlunos;
            TempData.Keep();

            return View("Index", listaAlunos);

        }


        [HttpGet]
        [Route("Aluno/Filtrar/{nome?}")]
        public ActionResult Filtrar(string nome = "")
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Alunos",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Alunos", ActionName = "Index", ControllerName = "Aluno"},
                 new BreadCrumb {LinkText = "Filtro", ActionName = "Filtro", ControllerName = "Aluno"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            ViewBag.Status = ObterListaStatusParaCombo();
            ViewBag.Responsavel = ObterListaResponsavelParaCombo();
            var listaAlunos = alunoAppService.Filtrar(nome);

            return View("Index", listaAlunos);
        }

        public ActionResult Edit(int id)
        {
            var alunoVm = alunoAppService.ObterPorId(id);

            var aluno = new
            {
                alunoVm.Codigo,
                alunoVm.Nome,
                StatusId = alunoVm.Status.Codigo,
                Status = alunoVm.Status.Descricao,
                ResponsavelId = alunoVm.Responsavel.Codigo,
                alunoVm.DataNascimento,
                alunoVm.GrupoDeJovens,
                alunoVm.Matriculado,
                alunoVm.Observacao,
                alunoVm.Sexo
            };


            return Json(aluno, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public ActionResult Gravar(int codigo,
                                   string nome,
                                   int responsavelId,
                                   DateTime dataNascimento,
                                   bool matriculado,
                                   bool grupoDeJovens,
                                   int statusId)
        {
            var aluno = new AlunoViewModel
            {
                Codigo = codigo,
                Nome = nome,
                Responsavel = new ResponsavelViewModel
                {
                    Codigo = responsavelId
                },
                DataNascimento = dataNascimento,
                GrupoDeJovens = grupoDeJovens,
                Matriculado = matriculado,
                Status = new StatusViewModel
                {
                    Codigo = statusId
                }
            };
            var gravarResult = alunoAppService.Gravar(aluno);
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
            var excluirResult = alunoAppService.Excluir(id);

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

        public ActionResult ObterNomesParaPesquisa()
        {
            var listaNomes = alunoAppService.ObterTodos().Select(dado => dado.Nome);

            return Json(String.Join(", ", listaNomes.ToList()), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region private methods
        private SelectList ObterListaStatusParaCombo()
        {
            var listaStatus = statusAppService.ObterTodos();
            var statusList = new SelectList(listaStatus, "Codigo", "Descricao");

            return statusList;
        }

        private SelectList ObterListaResponsavelParaCombo()
        {
            var listaResponsavel = responsavelAppService.ObterTodos();
            var responsavelList = new SelectList(listaResponsavel.OrderBy(resp => resp.Responsavel1), "Codigo", "Responsavel1");

            return responsavelList;
        }

        #endregion
    }
}