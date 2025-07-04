using System;

namespace CursoLINQ;

public class LinqQueries
{
    private List<Book> librosColecction = new();
    public LinqQueries()
    {
        using (StreamReader reader = new("books.json"))
        {
            string json = reader.ReadToEnd();
            this.librosColecction = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true, })
                ?? new List<Book>();
        }
    }

    public IEnumerable<Book> TodaLaColeccion() => librosColecction;

    public IEnumerable<Book> LibrosDespuesDel2000() => librosColecction
                                                        .Where(libro => libro.PublishedDate.Year > 2000);

    public IEnumerable<Book> LibrosConMasDe500Paginas()
    {
        // Query Syntax
        var librosConMasDe500Paginas = from libro in librosColecction
                                       where libro.PageCount > 500
                                       select libro;

        // Method Syntax
        // var librosConMasDe500Paginas = librosColecction.Where(libro => libro.PageCount > 500);

        return librosConMasDe500Paginas;
    }

    public IEnumerable<Book> LibrosConMasDe250PaginasConPalabrasInAction() => librosColecction
                                                                               .Where(libro => libro.PageCount > 250 && libro.Title!.Contains("in Action"));

    public bool TodosLosLibrosTienenStatus() => librosColecction
                                                .All(libro => libro.Status is not null);

    public bool AlgunoFuePublicadoEn2005() => librosColecction
                                              .Any(libro => libro.PublishedDate.Year == 2005);

    public IEnumerable<Book> LibrosDePython() => librosColecction
                                                  .Where(libro => libro.Categories!.Contains("Python"));

    public IEnumerable<Book> LibrosDeJavaPorNombreAscendente() => librosColecction
                                                                   .Where(libro => libro.Categories!.Contains("Java"))
                                                                   .OrderBy(libro => libro.Title);

    public IEnumerable<Book> LibrosDeMas450PaginasOrdenadosPorNumeroDePaginasDescendente() => librosColecction
                                                                                               .Where(libro => libro.PageCount > 450)
                                                                                               .OrderByDescending(libro => libro.PageCount);

    public IEnumerable<Book> TresPrimerosLibrosOrdenadosPorFecha() => librosColecction
                                                           .Where(libro => libro.Categories!.Contains("Java"))
                                                           .OrderByDescending(libro => libro.PublishedDate)
                                                           .Take(3);

    public IEnumerable<Book> TercerYCuartoLibroDeMasDe400Paginas() => librosColecction
                                                             .Where(libro => libro.PageCount > 400)
                                                             .Take(4)
                                                             .Skip(2);

    public IEnumerable<Book> TresPrimerosLibrosDeLaColeccion()
    {
        return librosColecction
            .Take(3)
            .Select(libro => new Book()
            {
                Title = libro.Title,
                PageCount = libro.PageCount,
            });
    }

    public int CantidadDeLibrosEntre200Y500Paginas() => librosColecction
                                                            .Where(libro => libro.PageCount >= 200 && libro.PageCount <= 500).Count();

    public DateTime FechaDePublicacionMenor()
    {
        return (DateTime)librosColecction
            .Min(libro => libro.PublishedDate)!;
    }


    public int NumeroDePaginasLibrosMayor()
    {
        return librosColecction
            .Max(libro => libro.PageCount);
    }

    public Book LibroConMenorNumeroDePaginas() => librosColecction
                                                      .Where(libro => libro.PageCount > 0)
                                                      .MinBy(libro => libro.PageCount)!;

    public Book LibroConFechaPublicacionMasReciente() => librosColecction
        .MaxBy(libro => libro.PublishedDate)!;

    public int SumarDeTodasLasPaginasLibrosEntre0y500()
    {
        return librosColecction
            .Where(libro => libro.PageCount >= 0 && libro.PageCount <= 500)
            .Sum(libro => libro.PageCount);
    }

    public string TitulosDeLibrosDespuesDel2015Concatenados()
    {
        return librosColecction
            .Where(libro => libro.PublishedDate.Year > 2015)
            .Aggregate("", (TitulosLibros, next) =>
            {
                if (TitulosLibros != string.Empty)
                    TitulosLibros += " - " + next.Title;
                else
                    TitulosLibros += next.Title;

                return TitulosLibros;

            });
    }

    public double PromediCaracteresTitulos()
    {
        return librosColecction
            .Average(libro => libro.Title!.Length);
    }

    public IEnumerable<IGrouping<int, Book>> LibrosDespuesDel2000AgrupadosPorAno()
    {
        return librosColecction
            .Where(libro => libro.PublishedDate.Year > 2000)
            .GroupBy(libro => libro.PublishedDate.Year);
    }

    public ILookup<char, Book> DiccionariosDeLibrosPorLetra()
    {
        return librosColecction
            .ToLookup(libro => libro.Title![0], libro => libro);
    }

    public IEnumerable<Book> LibrosDespuesDel2005ConMasDe500Paginas()
    {
        var librosDespuesDel2005 = librosColecction
            .Where(libro => libro.PublishedDate.Year > 2005);

        var librosConMasDe500Paginas = librosColecction
            .Where(libro => libro.PageCount > 500);

        return librosDespuesDel2005.Join(librosConMasDe500Paginas, libroA => libroA.Title, libroB => libroB.Title, (libroA, libroB) => libroA);
            
    }

}
