using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace RPGHelper.Modules
{
    public class Dice : ModuleBase<SocketCommandContext>
    {
        [Command("roll")]
        public async Task Roll20(int numero)
        {
            Random rd = new Random();
            var dice = rd.Next(1, numero + 1);
            var character = ((Discord.WebSocket.SocketGuildUser)Context.Message.Author).Nickname;
            await Context.Channel.SendMessageAsync($"{character} - D{numero}:   {dice}");
        }

        [Command("roll")]
        public async Task Roll20(int numero, int numeroDados)
        {
            Random rd = new Random();          
            var total = 0;
            var mensagem = $"D{ numero}: ";

            for (int i = 0; i < numeroDados; i++)
            {
                var dice = rd.Next(1, numero + 1);
                total += dice;

                if (i == 0)
                    mensagem += $"{dice}";
                else
                    mensagem += $" + {dice}";
            }
            var character = ((Discord.WebSocket.SocketGuildUser)Context.Message.Author).Nickname;
            await Context.Channel.SendMessageAsync($"{character} - {mensagem}");
            await Context.Channel.SendMessageAsync($"Total {character}:   {total}");
        }

        [Command("help")]
        public async Task Help()
        {
            string mensagem = "Olá caro aventureiro. \n";
            mensagem += "Digitando !roll você tem 2 opções \n";
            mensagem += "!roll + o número de lados do dado e eu te retornarei um valor entre 1 e o número total de dados \n";
            mensagem += "Exemplo: '!roll 20'  \n";
            mensagem += "D20: 17 \n";
            mensagem += "Sendo D20 o tipo de dado rolado (no caso um dado de 20 lados) e 17 o valor tirado \n";
            mensagem += "Ou então !roll + número de lados do dado + número de vezes que quer jogar o dado. \n";
            mensagem += "Exemplo: '!roll 10 3' \n";
            mensagem += "D10: 8 + 9 + 6 \n";
            mensagem += "Total:   23 \n";
            mensagem += "Sendo D10 o tipo de dado rolado (no caso um dado de 10 lados), 8, 9 e 6 pois ele foi jogado 3 vezes e 23 sendo a soma de todos os resultados \n";
            mensagem += "Aventure-se!!!";

            await Context.Channel.SendMessageAsync($"{mensagem}");
        }
    }
}
