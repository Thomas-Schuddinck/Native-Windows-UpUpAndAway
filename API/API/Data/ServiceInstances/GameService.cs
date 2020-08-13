using API.Data.IServices;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.ServiceInstances
{
    public class GameService : IGameService
    {
        private readonly Context context;
        private readonly DbSet<Game> games;
        private readonly DbSet<GamePair> gamePairs;
        private readonly DbSet<Passenger> passengers;

        public GameService(Context context)
        {
            this.context = context;
            games = context.Games;
            gamePairs = context.GamePairs;
            passengers = context.Passengers;
        }

        public bool CreateGame(NewGameDTO newGameDTO)
        {
            return CreatePair(newGameDTO) > 0;
        }

        public bool UpdateHangman(SimpleHangmanDTO dto)
        {
            var game = (HangmanGame)games.SingleOrDefault(s => s.GameId == dto.GameId) ?? throw new ArgumentException();
            game.Guesses = dto.Guesses.ToList();
            game.Evaluate();
            games.Update(game);
            context.SaveChanges();
            return true;
        }

        public ICollection<Game> GetByUser(int passengerId)
        {
            return games
                .Where(g => g.Player.PassengerId == passengerId)
                .Include(g => g.GamePair).ThenInclude(g => g.FirstGame).ThenInclude(g => g.Player)
                .Include(g => g.GamePair).ThenInclude(g => g.SecondGame).ThenInclude(g => g.Player)
                .Include(g => g.Player)
                .AsNoTracking().ToList();
        }

        public Game GetById(int gameId)
        {
            return games
                .Include(g => g.GamePair)
                .Include(g => g.Player)
                .SingleOrDefault(g => g.GameId == gameId);
        }

        public HangmanGame GetHangmanById(int gameId)
        {
            var t = games
                .Include(g => g.GamePair).ThenInclude(gp => gp.FirstGame).ThenInclude(fg => fg.Player)
                .Include(g => g.GamePair).ThenInclude(gp => gp.SecondGame).ThenInclude(sg => sg.Player)
                .Include(g => g.Player)
                .SingleOrDefault(g => g.GameId == gameId);
            return (HangmanGame)t;
        }

        public bool UpdateGame(Game game)
        {
            var gameDB = games.SingleOrDefault(s => s.GameId == game.GameId) ?? throw new ArgumentException();

            return true;
        }

        private int CreatePair(NewGameDTO newGameDTO)
        {
            GamePair gamePair = new GamePair(newGameDTO.GameType, FindPassenger(newGameDTO.PlayerId1), FindPassenger(newGameDTO.PlayerId2));
            gamePairs.Add(gamePair);
            context.SaveChanges();
            gamePair.SetGamePairForGames();
            context.SaveChanges();
            return gamePair.GamePairId;
        }

        private Passenger FindPassenger(int id)
        {
            return passengers.FirstOrDefault(p => p.PassengerId == id);
        }

        public bool SetWordForGame(HangmanWordDTO dto)
        {
            var game = (HangmanGame)games
                .Include(g => g.GamePair).ThenInclude(g => g.FirstGame).ThenInclude(g => g.Player)
                .Include(g => g.GamePair).ThenInclude(g => g.SecondGame).ThenInclude(g => g.Player)
                .SingleOrDefault(s => s.GameId == dto.GameId) ?? throw new ArgumentException();
            game.SetWord(dto.Word);
            games.Update(game);
            context.SaveChanges();
            return true;
        }
    }
}
