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

        public ICollection<Game> GetByUser(int passengerId)
        {
            return games
                .Where(g => g.Player.PassengerId == passengerId)
                .Include(g => g.GamePair)
                .AsNoTracking().ToList();
        }

        public Game GetById(int gameId)
        {
            return games
                .Include(g => g.GamePair)
                .Include(g => g.Player)
                .SingleOrDefault(g => g.GameId == gameId);
        }

        public bool UpdateGame(Game game)
        {
            throw new NotImplementedException();
        }

        private int CreatePair(NewGameDTO newGameDTO)
        {
            GamePair gamePair = new GamePair(newGameDTO.GameType, FindPassenger(newGameDTO.PlayerId1), FindPassenger(newGameDTO.PlayerId2));
            gamePairs.Add(gamePair);
            context.SaveChanges();
            return gamePair.GamePairId;
        }

        private Passenger FindPassenger(int id)
        {
            return passengers.FirstOrDefault(p => p.PassengerId == id);
        }
    }
}
