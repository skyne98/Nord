﻿using System;
using Newtonsoft.Json;
using Nord.Compiler.Lexer;
using Nord.Compiler.Parser;
using Superpower;
using Superpower.Model;
using YamlDotNet.Serialization;

namespace Nord.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("nord> ");
            var line = Console.ReadLine();
            while (line != null)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    if (Parsers.TryParse(line, out var value, out var error, out var errorPosition))
                    {
                        var serializer = new SerializerBuilder().Build();
                        try
                        {
                            Console.WriteLine(serializer.Serialize(value));
                        }
                        catch
                        {
                            try
                            {
                                Console.WriteLine(JsonConvert.SerializeObject(value, Formatting.Indented));
                            }
                            catch
                            {
                                Console.WriteLine("There was a problem with serialization");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"     {new string(' ', errorPosition.Column)}^");
                        Console.WriteLine(error);
                    }
                }
                
                Console.Write("nord> ");
                line = Console.ReadLine();
            }
        }
    }
}