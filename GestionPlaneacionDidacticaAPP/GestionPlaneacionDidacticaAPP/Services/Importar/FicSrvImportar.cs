using GestionPlaneacionDidacticaAPP.Data;
using GestionPlaneacionDidacticaAPP.Interfaces.Importar;
using GestionPlaneacionDidacticaAPP.Interfaces.SQLite;
using GestionPlaneacionDidacticaAPP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using Newtonsoft.Json;

namespace GestionPlaneacionDidacticaAPP.Services.Importar
{
    public class FicSrvImportar : IFicImportar
    {
        private readonly DBContext DBLoContext;
        private readonly HttpClient Client;
        public FicSrvImportar()
        {
            DBLoContext = new DBContext(DependencyService.Get<ConfigSQLite>().GetDataBasePath());
            Client = new HttpClient();
            Client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<string> FicMetExportar()
        {
            List<eva_planeacion> eva_planeacion = await (from item in DBLoContext.eva_planeacion select item).AsNoTracking().ToListAsync();
            List<eva_planeacion_temas> eva_planeacion_temas = await (from item in DBLoContext.eva_planeacion_temas select item).AsNoTracking().ToListAsync();
            List<eva_planeacion_temas_competencias> eva_planeacion_temas_competencias = await (from item in DBLoContext.eva_planeacion_temas_competencias select item).AsNoTracking().ToListAsync();
            List<eva_planeacion_apoyos> eva_planeacion_apoyos = await (from item in DBLoContext.eva_planeacion_apoyos select item).AsNoTracking().ToListAsync();
            List<eva_planeacion_aprendizaje> eva_planeacion_aprendizaje = await (from item in DBLoContext.eva_planeacion_aprendizaje select item).AsNoTracking().ToListAsync();
            List<eva_planeacion_criterios_evalua> eva_planeacion_criterios_evalua = await (from item in DBLoContext.eva_planeacion_criterios_evalua select item).AsNoTracking().ToListAsync();
            List<eva_planeacion_enseñanza> eva_planeacion_enseñanza = await (from item in DBLoContext.eva_planeacion_enseñanza select item).AsNoTracking().ToListAsync();
            List<eva_planeacion_fuentes> eva_planeacion_fuentes = await (from item in DBLoContext.eva_planeacion_fuentes select item).AsNoTracking().ToListAsync();
            List<eva_planeacion_mejora_desempeño> eva_planeacion_mejora_desempeño = await (from item in DBLoContext.eva_planeacion_mejor_desempeño select item).AsNoTracking().ToListAsync();
            List<eva_planeacion_subtemas> eva_planeacion_subtemas = await (from item in DBLoContext.eva_planeacion_subtemas select item).AsNoTracking().ToListAsync();
            ImportarExportar aux = new ImportarExportar(eva_planeacion, eva_planeacion_temas, eva_planeacion_temas_competencias, eva_planeacion_apoyos,eva_planeacion_aprendizaje
                ,eva_planeacion_criterios_evalua,eva_planeacion_enseñanza,eva_planeacion_fuentes,eva_planeacion_mejora_desempeño,eva_planeacion_subtemas);

            return PostExportarPlaneacion(aux).Result;
        }
        private async Task<string> PostExportarPlaneacion(ImportarExportar item)
        {
            string url = "http://localhost:53483/api/ExportarPlaneacion";
            HttpResponseMessage res = await Client.PostAsync(new Uri(string.Format(url, string.Empty)),
                new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json"));
            return res.IsSuccessStatusCode ? "OK" : "ERROR";
        }

        public Task<ImportarExportar> FicMetImportar()
        {
            throw new NotImplementedException();
        }
        private async Task<ImportarExportar> GetImportarPlaneacion()
        {
            string url = "http://localhost:53483/api/ImportarPlaneacion";
            var res = await Client.GetAsync(url);
            return res.IsSuccessStatusCode ? JsonConvert.DeserializeObject<ImportarExportar>(await res.Content.ReadAsStringAsync()) : null;
        }
    }
}
