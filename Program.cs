using CursoLINQ;

LinqQueries linqQueries = new();

// Toda La coleccion
ImprimirValores(linqQueries.TodaLaColeccion());

// Libros publicados después del 2000
ImprimirValores(linqQueries.LibrosDespuesDel2000());

// Libros con más de 250 páginas con palabras "in Action"
ImprimirValores(linqQueries.LibrosConMasDe250PaginasConPalabrasInAction());

// Status de los libros
Console.WriteLine(linqQueries.TodosLosLibrosTienenStatus() ? "Todos los libros tienen status." : "No todos los libros tienen status.");

// Si algun libro fue publicado en 2005
Console.WriteLine(linqQueries.AlgunoFuePublicadoEn2005() ? "Al menos un libro fue publicado en 2005." : "Ningún libro fue publicado en 2005.");

// Libros de Python
ImprimirValores(linqQueries.LibrosDePython());

// Libros de Java ordenados por nombre
ImprimirValores(linqQueries.LibrosDeJavaPorNombreAscendente());

// Libros que tienen mas de 450 paginas ordenados por cantidad de paginas
ImprimirValores(linqQueries.LibrosDeMas450PaginasOrdenadosPorNumeroDePaginasDescendente());

// Los 3 libros de Java publicados recientemente
ImprimirValores(linqQueries.TresPrimerosLibrosOrdenadosPorFecha());

// Tercer y cuarto libro con mas de 400 paginas
ImprimirValores(linqQueries.TercerYCuartoLibroDeMasDe400Paginas());

// Tres primeros libros filtrados con Select()
ImprimirValores(linqQueries.TresPrimerosLibrosDeLaColeccion());

// Cantidad que tienen entre 200 y 500 paginas
Console.WriteLine($"Cantidad de libros con entre 200 y 500 páginas: {linqQueries.CantidadDeLibrosEntre200Y500Paginas()}");

// Fecha de publicacion menor de todos los libros 
Console.WriteLine($"Fecha de Publicacion menor: {linqQueries.FechaDePublicacionMenor()}");

// Numero de paginas del libro con mayor Numero de Paginas
Console.WriteLine($"Número de páginas del libro con mayor número de páginas: {linqQueries.NumeroDePaginasLibrosMayor()}");

// Libro con menor numero de paginas
var libroMenorPag = linqQueries.LibroConMenorNumeroDePaginas();
// Console.WriteLine($"Libro con menor número de páginas: {libroMenorPag.Title} - {libroMenorPag.PageCount}");

// Libro con fecha publicacion mas reciente
var libroFechaPublicacionReciente = linqQueries.LibroConFechaPublicacionMasReciente();
// Console.WriteLine($"Libro con fecha de publicación más reciente: {libroFechaPublicacionReciente.Title} - {libroFechaPublicacionReciente.PublishedDate?.ToShortDateString()}");

// Suma de paginas de libros entre 0 y 500
Console.WriteLine($"Suma Total de páginas de libros entre 0 y 500: {linqQueries.SumarDeTodasLasPaginasLibrosEntre0y500()}");

// Libros publicado despues del 2015
Console.WriteLine(linqQueries.TitulosDeLibrosDespuesDel2015Concatenados());

// El promedio de caracteres de los títulos de los libros
Console.WriteLine($"Promedio de caracteres de los títulos de los libros: {linqQueries.PromediCaracteresTitulos()}");

// Libros publicados a partir del 2000 agrupados por año
ImprimirGrupo(linqQueries.LibrosDespuesDel2000AgrupadosPorAno());

// Diccionario de libros agrupados por primera letra del titulo
var diccionarioLibros = linqQueries.DiccionariosDeLibrosPorLetra();
ImprimirDiccionario(diccionarioLibros, 'S');

// Libros filtrados con la clausula JOIN
ImprimirValores(linqQueries.LibrosDespuesDel2005ConMasDe500Paginas());


void ImprimirValores(IEnumerable<Book> listaDeLibros)
{
    Console.WriteLine("{0,-60} {1,15} {2,15}", "Titulo", "Páginas", "Fecha Publicación");
    Console.WriteLine(new string('-', 100));
    foreach (var libro in listaDeLibros)
    {
        Console.WriteLine("{0,-60} {1,15} {2,15}",
                libro.Title,
                libro.PageCount,
                libro.PublishedDate.ToShortDateString());
    }
}

void ImprimirGrupo(IEnumerable<IGrouping<int, Book>> listaDeLibros)
{
    foreach (var grupo in listaDeLibros)
    {
        Console.WriteLine("");
        Console.WriteLine($"Grupo: {grupo.Key}");
        Console.WriteLine("{0,-60} {1,15} {2,15}\n", "Titulo", "N. Páginas", "Fecha Publicación");
        foreach (var libro in grupo)
        {
            Console.WriteLine("{0,-60} {1,15} {2,15}",
                libro.Title,
                libro.PageCount,
                libro.PublishedDate.ToShortDateString());
        }
    }
}


void ImprimirDiccionario(ILookup<char, Book> listaDeLibros, char letra)
{
    Console.WriteLine("{0,-60} {1,15} {2,15}\n", "Titulo", "N. Páginas", "Fecha Publicación");
    foreach (var item in listaDeLibros[letra])
    {
        Console.WriteLine("{0,-60} {1,15} {2,15}",
            item.Title,
            item.PageCount,
            item.PublishedDate.ToShortDateString());
    }
}









