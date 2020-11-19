using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MiCli
{
    class CrearControlador
    {
        private string modeloPrincipal { get; set; }
        private string modeloPrincipalConPrimeraLetraEnMinuscula;
        private string modeloPrincipalEnPlural;
        

        Helpers helpers = new Helpers();        

        public void procesarElNombreDelModelo(string elModeloPrincipal)
        {
            modeloPrincipal = elModeloPrincipal;
            modeloPrincipalConPrimeraLetraEnMinuscula = helpers.PonerPrimeraLetraEnMinuscula(elModeloPrincipal);
            modeloPrincipalEnPlural = helpers.QuitarPlural(elModeloPrincipal);
        }

        public string Variables()
        {
            string lasVariables = "     private readonly ApplicationDbContext _context;" + Environment.NewLine +
                "       private readonly IMapper _mapper;" + Environment.NewLine;

            return lasVariables;
        }                

        public string InyeccionDeDependencias()
        {
            string contextYMapper = Environment.NewLine +
                           "        private readonly ApplicationDbContext _context;" + Environment.NewLine +
                          "     private readonly IMapper _mapper;" + Environment.NewLine + Environment.NewLine +
                          "     public " + modeloPrincipal + "Controller(ApplicationDbContext context, IMapper mapper)" + Environment.NewLine +
                          "     {" + Environment.NewLine +
                          "          _context = context;" + Environment.NewLine +
                          "          _mapper = mapper;" + Environment.NewLine +
                          "     }" + Environment.NewLine + Environment.NewLine;

            return contextYMapper;
        }

        public string IndexViewModelHechoCon2Modelos(string viewModel, string modeloPrincipal, string modeloSecundario)
        {
            string modeloQueIniciaConMinuscula = helpers.PonerPrimeraLetraEnMinuscula(viewModel);

            string index = "// GET: " + modeloPrincipal + Environment.NewLine +
                "public async Task<IActionResult> Index()" + Environment.NewLine +
                "{" + Environment.NewLine +
                "  try" + Environment.NewLine +
                "  {" + Environment.NewLine +
                "    var " + helpers.PonerPrimeraLetraEnMinuscula(modeloPrincipal) + " = await _context." + modeloPrincipal + Environment.NewLine +
                "    .Include(c => c." + modeloPrincipal + ")" + Environment.NewLine +
                "     .ToListAsync();" + Environment.NewLine + Environment.NewLine +
                "     List<" + viewModel + "> data = _mapper.Map<List<" + modeloPrincipal + ">," + Environment.NewLine +
                "               List<" + viewModel + ">>(" + helpers.PonerPrimeraLetraEnMinuscula(modeloPrincipal) + ");" + Environment.NewLine + Environment.NewLine +
                "     return View(data);" + Environment.NewLine +
                "   }" + Environment.NewLine +
                "     catch (Exception e)" + Environment.NewLine +
                "   {" + Environment.NewLine +
                "     Console.WriteLine(e.Message);" + Environment.NewLine +
                "     return NotFound();" + Environment.NewLine +
                "   }    " + Environment.NewLine +
                "}" + Environment.NewLine + Environment.NewLine; 
                
            return index;
        }

        public string DetailsViewModelHechoCon2Modelos(string viewModel, string modeloPrincipal, string modeloSecundario)
        {
            string modeloQueIniciaConMinuscula = helpers.PonerPrimeraLetraEnMinuscula(viewModel);

            string index = "// GET:" + modeloPrincipal + "/Details/5 " + Environment.NewLine +
                "public async Task<IActionResult> Details(int? id)" + Environment.NewLine +
                "{" + Environment.NewLine +
                "  if (id == null)" + Environment.NewLine +
                "  {" + Environment.NewLine +
                "    return NotFound();" + Environment.NewLine +
                "  }" + Environment.NewLine + Environment.NewLine +
                "  var data = await _context" + modeloPrincipal + Environment.NewLine +
                "    .Include(c => c." + modeloSecundario + ")" + Environment.NewLine +
                "    .FirstOrDefaultAsync(m => m.Id" + modeloPrincipal + " == id);" + Environment.NewLine + Environment.NewLine +
                "  if (data == null)" + Environment.NewLine +
                "  {" + Environment.NewLine +
                "     return NotFound();" + Environment.NewLine +
                "  }" + Environment.NewLine + Environment.NewLine +
                "  var model = _mapper.Map<" + modeloPrincipal + ", " + viewModel + ">(data);" + Environment.NewLine + Environment.NewLine +
                "  return View(model);" + Environment.NewLine +
                "}    " + Environment.NewLine + Environment.NewLine;

            return index;
        }

        public string CreateViewModelHechoCon2Modelos(string viewModel, string modeloPrincipal, string modeloSecundario)
        {
            string modeloQueIniciaConMinuscula = helpers.PonerPrimeraLetraEnMinuscula(viewModel);

            string index = "// GET:" + modeloPrincipal + "/Create" + Environment.NewLine +
                "public async IActionResult Create()" + Environment.NewLine +
                "{" + Environment.NewLine +
                "   ViewData[\"" + modeloSecundario + "Name\"] = new SelectList(_context." + helpers.PonerPlural(modeloSecundario) + ", \"Id" + modeloSecundario + "\", \"" +  modeloSecundario + "Name\");" 
                + Environment.NewLine + Environment.NewLine +                
                "   return View();" + Environment.NewLine +
                "}    " + Environment.NewLine + Environment.NewLine +
                "// POST: " + modeloPrincipal + "/Create" + Environment.NewLine +
                "[HttpPost]" + Environment.NewLine +
                "[ValidateAntiForgeryToken]" + Environment.NewLine +
                "public async Task<IActionResult> Create([Bind(\"Id" + helpers.QuitarPlural(modeloPrincipal) + "," + modeloPrincipal + "Name,Id" + modeloSecundario + "\")] " + viewModel + " " + 
                helpers.PonerPrimeraLetraEnMinuscula(viewModel) + ")" + Environment.NewLine +
                "{" + Environment.NewLine +
                "  if (ModelState.IsValid)" + Environment.NewLine +
                "  {" + Environment.NewLine +
                "       try" + Environment.NewLine +
                "       {" + Environment.NewLine +
                "         var data = _mapper.Map<" + viewModel + ", " + modeloPrincipal + ">(" + viewModel + ");" + Environment.NewLine +
                "         _context.Add(data);" + Environment.NewLine +
                "         await _context.SaveChangesAsync();" + Environment.NewLine + Environment.NewLine +
                "         return RedirectToAction(nameof(Index));" + Environment.NewLine +
                "       }" + Environment.NewLine +
                "       catch (Exception e)" + Environment.NewLine +
                "       {" + Environment.NewLine +
                "         Console.WriteLine(e.Message);" + Environment.NewLine +
                "       }" + Environment.NewLine +
                "   }" + Environment.NewLine + Environment.NewLine +
                "   ViewData[\"Id" + modeloSecundario + "\"] = new SelectList(_context." + modeloSecundario + ", \"Id" + modeloSecundario + "\", \"" + modeloSecundario + "Name\");" + Environment.NewLine +
                Environment.NewLine +
                "   return View(" + viewModel + ");" + Environment.NewLine +
                "}" + Environment.NewLine +
                Environment.NewLine;

            return index;
        }

        public string CrearIndexConUnModelo()
        {
            string index = "        // GET: " + modeloPrincipal + Environment.NewLine +
               "        public async Task<IActionResult> Index()" + Environment.NewLine +
               "        {" + Environment.NewLine +
               "          try" + Environment.NewLine +
               "          {" + Environment.NewLine +
               "            var " + helpers.QuitarPlural(helpers.PonerPrimeraLetraEnMinuscula(modeloPrincipal)) + " = await _context." + modeloPrincipal + ".ToListAsync();" + Environment.NewLine +               
               "             List<" + modeloPrincipal + "Dto> data = _mapper.Map<List<" + modeloPrincipal + ">," + Environment.NewLine +
               "                       List<" + modeloPrincipal + "Dto>>(await _context." + modeloPrincipal + ".ToListAsync());" + Environment.NewLine + Environment.NewLine +
               "             return View(data);" + Environment.NewLine +
               "           }" + Environment.NewLine +
               "             catch (Exception e)" + Environment.NewLine +
               "           {" + Environment.NewLine +
               "             Console.WriteLine(e.Message);" + Environment.NewLine +
               "             return NotFound();" + Environment.NewLine +
               "           }    " + Environment.NewLine +
               "        }" + Environment.NewLine + Environment.NewLine;

            return index;
        }

        public string CrearDetailsConUnModelo() 
        {
            string details = "      // GET: " + modeloPrincipal + "/Details/5" + Environment.NewLine +
                "       public async Task<IActionResult> Details(int? id)" + Environment.NewLine +
                "       {" + Environment.NewLine +
                "          if (id == null)" + Environment.NewLine +
                "          {" + Environment.NewLine +
                "              return NotFound();" + Environment.NewLine +
                "          }" + Environment.NewLine + Environment.NewLine +
                "          var " + modeloPrincipalConPrimeraLetraEnMinuscula + " = await _context." + modeloPrincipal + ".FirstOrDefaultAsync(m => m.Id" +
                modeloPrincipalEnPlural + " == id);" + Environment.NewLine + Environment.NewLine +
                "          if (" + modeloPrincipalConPrimeraLetraEnMinuscula + " == null)" + Environment.NewLine +
                "          {" + Environment.NewLine +
                "              return NotFound();" + Environment.NewLine +
                "          }" + Environment.NewLine + Environment.NewLine +
                "          var model = _mapper.Map<" + modeloPrincipal + ", " + modeloPrincipal + "Dto>(" + modeloPrincipalConPrimeraLetraEnMinuscula + ");" + Environment.NewLine + Environment.NewLine +
                "          return View(model);" + Environment.NewLine +                
                "       }" + Environment.NewLine 
                ;

            return details;
        }

        public string CrearCreateConUnModelo()
        {
            string details = "      // GET: " + modeloPrincipal + "/Create" + Environment.NewLine +
                "       public IActionResult Create()" + Environment.NewLine +
                "       {" + Environment.NewLine +
                "          return View();" + Environment.NewLine +
                "       }" + Environment.NewLine + Environment.NewLine +
                "       // POST: CustomerCountries/Create" + Environment.NewLine +
                "       // To protect from overposting attacks, enable the specific properties you want to bind to, for " + Environment.NewLine +
                "       [HttpPost]" + Environment.NewLine +
                "       [ValidateAntiForgeryToken]" + Environment.NewLine +
                "       public async Task<IActionResult> Create(" + modeloPrincipal +"Dto " + modeloPrincipalConPrimeraLetraEnMinuscula + "Dto)" + Environment.NewLine +
                "       {" + Environment.NewLine +
                "          if (ModelState.IsValid)" + Environment.NewLine +
                "          {" + Environment.NewLine +
                "               var data = _mapper.Map<" + modeloPrincipal + "Dto, " + modeloPrincipal + ">(" + modeloPrincipalConPrimeraLetraEnMinuscula + "Dto);" + Environment.NewLine +
                "               _context.Add(data);" + Environment.NewLine +
                "               await _context.SaveChangesAsync();" + Environment.NewLine +
                "               return RedirectToAction(nameof(Index));" + Environment.NewLine +
                "           }" + Environment.NewLine + Environment.NewLine +
                "           return View();" + Environment.NewLine +
                "       }" + Environment.NewLine                 
                ;

            return details;
        }

    }
}
