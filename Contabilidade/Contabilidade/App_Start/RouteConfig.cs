using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BootstrapMvcSample.Controllers;
using NavigationRoutes;
using Contabilidade.Controllers;

namespace Contabilidade
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapNavigationRoute<UsuarioViewController>("Usuario", r => r.Start())
                .AddChildRoute<UsuarioViewController>("Listagem", r => r.Index())
                .AddChildRoute<UsuarioViewController>("Incluir", r => r.Create());

            routes.MapNavigationRoute<SetorViewController>("Setor", r => r.Start())
                .AddChildRoute<SetorViewController>("Listagem", r => r.Index())
                .AddChildRoute<SetorViewController>("Incluir", r => r.Create());

            routes.MapNavigationRoute<ObrigacaoViewController>("Obrigacao", r => r.Start())
                .AddChildRoute<ObrigacaoViewController>("Listagem", r => r.Index())
                .AddChildRoute<ObrigacaoViewController>("Incluir", r => r.Create());

            routes.MapNavigationRoute<ClienteController>("Cliente", r => r.Start())
                .AddChildRoute<ClienteController>("Listagem", r => r.Index())
                .AddChildRoute<ClienteController>("Incluir", r => r.Create());

            routes.MapNavigationRoute<EtapaController>("Etapa", r => r.Start())
                .AddChildRoute<EtapaController>("Listagem", r => r.Index())
                .AddChildRoute<EtapaController>("Incluir", r => r.Create());

            routes.MapNavigationRoute<OrdemDeServicoController>("Ordem de Serviço", r => r.Start())
                .AddChildRoute<OrdemDeServicoController>("Listagem", r => r.Index())
                .AddChildRoute<OrdemDeServicoController>("Incluir", r => r.Create());

            routes.MapNavigationRoute<RelatorioOSController>("Relatório de OS", r => r.Start())
                .AddChildRoute<RelatorioOSController>("Relatório", r => r.Create());

            //routes.MapNavigationRoute<HomeController>("Automatic Scaffolding", c => c.Index());

            //routes.MapNavigationRoute<ExampleLayoutsController>("Example Layouts", c => c.Starter())
            //      .AddChildRoute<ExampleLayoutsController>("Marketing", c => c.Marketing())
            //      .AddChildRoute<ExampleLayoutsController>("Fluid", c => c.Fluid())
            //      .AddChildRoute<ExampleLayoutsController>("Sign In", c => c.SignIn());

        }
    }
}