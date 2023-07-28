using System;
using System.Collections.Generic;

namespace YandexTestTask.Gameplay
{
    public class GameLoop : IGameLoopObject, IGameLoop
    {
        private readonly List<IGameLoopObject> _loopObjects;

        public GameLoop(List<IGameLoopObject> loopObjects)
        {
            _loopObjects = loopObjects ?? throw new ArgumentNullException(nameof(loopObjects));
        }

        public void Add(IGameLoopObject loopObject)
        {
            if (loopObject == null) 
                throw new ArgumentNullException(nameof(loopObject));
            
            _loopObjects.Add(loopObject);
        }
        
        public void Update(float deltaTime)
        {
            _loopObjects.ForEach(loopObject => loopObject.Update(deltaTime));
        }
    }
}