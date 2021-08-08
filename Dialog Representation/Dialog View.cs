using System;
using static System.Console;
using System.Collections.Generic;

class Program {
    static void Main() {
        List<Question> questions = new() {
            new OptionsQ("web shop", "Chces stranku nebo eshop?", new List<Edge>() { new Edge("Eshop", "Kolik produktu"), new Edge("Web", "Velky") }),
            new IntQ("Kolik produktu", "Kolik prodktu v eshopu chces?", new List<Edge>() { new Edge("Velky") }, 1, 1_000_000),
            new OptionsQ("Velky", "Chces to velky?", new List<Edge> { new Edge("Ano", "SEO"), new Edge("Ne", "SEO") }),
            new OptionsQ("SEO", "Chces SEO?", new List<Edge> { new Edge("Ano", "KolikSEA"), new Edge("Ne", "Fotky") }),
            new IntQ("KolikSEA", "Kolike SEA chces?", new List<Edge> { new Edge("Fotky") }, 1, 1_000_000),
            new OptionsQ("Fotky", "Chces fotky?", new List<Edge> { new Edge("Ano", "KolikFotek"), new Edge("Ne", "DejMiEmail") }),
            new IntQ("KolikFotek", "Kolik fotek na web pridame?", new List<Edge> { new Edge("DejMiEmail") }, 1, 1_000_000),
            new EmailQ("DejMiEmail", "Jaky je tvuj email?", new List<Edge> { new Edge("END") })
        };

        DialogGraph dg = new(questions);

        WriteLine("Dialog Graph initiated.");

        while (true) {
            WriteLine("______________________________");
            WriteLine("Your current chatHistory is: ");

            foreach (Answer a in dg.GetChatHistory())
                WriteLine(a);

            WriteLine();
            WriteLine("Your next question is: ");
            Question q = dg.GetQuestion();
            WriteLine(q);

            WriteLine("Options: ");
            foreach (Edge e in q.options)
                Write(e.Name + " ");

            WriteLine();
            string odpovedUsera = ReadLine();

            if (dg.SetAnswer(odpovedUsera)) {
                WriteLine("Correct answer. \n");
            } else {
                WriteLine("Sorry bad answer.");
            }

            if (dg.GetQuestion().name == "END") {
                WriteLine("______________________________");
                WriteLine("Your final chatHistory is: ");

                foreach (Answer a in dg.GetChatHistory())
                    WriteLine(a);

                WriteLine("Thank you for talking to me. Have a nice day.");
                break;
            }
        }
    }
}

