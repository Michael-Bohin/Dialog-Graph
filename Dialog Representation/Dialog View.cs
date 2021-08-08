using System;
using static System.Console;
using System.Collections.Generic;

class Program {
    static void Main() {
        WriteLine("Hello World!");

        List<Question> questions = new() {
            new OptionsQ( "web shop", "Chces stranku nebo eshop?", new List<Edge>() { new Edge("Eshop", "Kolik produktu"), new Edge("Web", "Velky") }),
            new IntQ("Kolik produktu", "Kolik prodktu v eshopu chces?", new List<Edge>() { new Edge("Velky") },  1, 1_000_000),
            new OptionsQ("Velky", "Chces to velky?", new List<Edge> { new Edge("Ano", "SEO"), new Edge("Ne", "SEO") }),
            new OptionsQ("SEO", "Chces SEO?", new List<Edge> { new Edge("Ano", "KolikSEA"), new Edge("Ne", "Fotky") } ),
            new IntQ("KolikSEA", "Kolike SEA chces?", new List<Edge> { new Edge(), new Edge() }),
            new OptionsQ(),
            new OptionsQ(),
        };
    }
}

