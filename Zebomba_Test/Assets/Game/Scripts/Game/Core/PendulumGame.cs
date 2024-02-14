using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Game.Scripts.Game.Controller;
using Game.Scripts.Game.Factory;
using Game.Scripts.Game.View;
using Game.Scripts.Infrastructure.Service;
using Game.Scripts.Infrastructure.States;
using UnityEngine;

namespace Game.Scripts.Game.Core
{
    public class PendulumGame : MonoBehaviour
    {
        [SerializeField] private List<TriggerZone> _triggerZones;
        [SerializeField] private GameView _gameView;
        
        private Pendulum _pendulum;
        private ICircleFactory _circleFactory;
        private Circle _currentCircle;
        private GameConfig _gameConfig;
        private GameStateMachine _gameStateMachine;
        private ScoreData _scoreData;
        private IInputService _inputService;
        private int _currentCircleCount;
        
        public void Init(
            Pendulum pendulum, 
            ICircleFactory circleFactory, 
            GameConfig gameConfig, 
            GameStateMachine gameStateMachine,
            ScoreData scoreData,
            IInputService inputService
        )
        {
            _pendulum = pendulum;
            _circleFactory = circleFactory;
            _gameConfig = gameConfig;
            _gameStateMachine = gameStateMachine;
            _scoreData = scoreData;
            _inputService = inputService;
            BaseInit();
        }

        private void BaseInit()
        {
            _scoreData.ResetScore();
            _gameView.SetScore(_scoreData.Score);
            CreateCircle();
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
        
        private void Update()
        {
            if(_inputService == null)
                return;
            
            CheckWin(_triggerZones);
            
            if (_currentCircleCount > _gameConfig.MaxCircles) 
                _gameStateMachine.Enter<GameOverState>();
            
            if (_inputService.IsTapPressed() && _currentCircle != null) 
                StartCoroutine(SpawnCircle());
            
            _pendulum?.Update(Time.time);
        }

        private IEnumerator SpawnCircle()
        {
            _currentCircle.DisconnectCircle(transform);
            _currentCircle = null;
            yield return new WaitForSeconds(1);
            CreateCircle();
        }

        private async Task CreateCircle()
        {
            _currentCircle = await _circleFactory.CreateCircle(_pendulum.Parent);
            _currentCircleCount += 1;
        }
        
        private void CheckWin(List<TriggerZone> columns)
        { 
            CheckHorizontal(columns);
            CheckVertical(columns);
            CheckDiagonal(columns);
        }

        private void CheckHorizontal(List<TriggerZone> columns)
        {
            if (columns.Any(column => column.CircleViews.Count < 1))
                return;
    
            for (int i = columns[0].CircleViews.Count - 1; i >= 0; i--)
            {
                if (columns.All(column => column.CircleViews.Count > i && column.CircleViews[i] != null))
                {
                    if (columns[0].CircleViews[i].CircleContent.ID == columns[1].CircleViews[i].CircleContent.ID &&
                        columns[1].CircleViews[i].CircleContent.ID == columns[2].CircleViews[i].CircleContent.ID)
                    {
                        SetScore(columns, i);
                        foreach (var column in columns)
                        {
                            column.CircleViews[i].Destroy();
                            column.CircleViews.RemoveAt(i);
                        }
                        _currentCircleCount -= _gameConfig.CircleCountForDestroy;
                    }
                }
            }
        }

        private void CheckVertical(List<TriggerZone> columns)
        {
            for (int i = 0; i < columns.Count; i++)
            {
                var column = columns[i];

                if (column.CircleViews == null || column.CircleViews.Count < 3)
                    continue;

                for (int j = 0; j < column.CircleViews.Count - 2; j++)
                {
                    var circleView1 = column.CircleViews[j];
                    var circleView2 = column.CircleViews[j + 1];
                    var circleView3 = column.CircleViews[j + 2];
                  
                    if (circleView1 != null && circleView2 != null && circleView3 != null &&
                        circleView1.CircleContent.ID == circleView2.CircleContent.ID &&
                        circleView2.CircleContent.ID == circleView3.CircleContent.ID)
                    {
                        SetScore(circleView1);
                        circleView1.Destroy();
                        circleView2.Destroy();
                        circleView3.Destroy();

                        column.CircleViews.RemoveAt(j);
                        column.CircleViews.RemoveAt(j);
                        column.CircleViews.RemoveAt(j);

                        _currentCircleCount -= _gameConfig.CircleCountForDestroy;
                    }
                }
            }
        }

        private void CheckDiagonal(List<TriggerZone> columns)
        {
            CheckDiagonalLine(columns, 0, 0, 1, 1, 2, 2);
            CheckDiagonalLine(columns, 0, 2, 1, 1, 2, 0);
        }

        private void CheckDiagonalLine(List<TriggerZone> columns, int x1, int y1, int x2, int y2, int x3, int y3)
        {
            if (IsValidIndex(columns, x1, y1) && IsValidIndex(columns, x2, y2) && IsValidIndex(columns, x3, y3))
            {
                CircleView circleView1 = columns[x1].CircleViews[y1];
                CircleView circleView2 = columns[x2].CircleViews[y2];
                CircleView circleView3 = columns[x3].CircleViews[y3];

                if (circleView1 != null && circleView2 != null && circleView3 != null &&
                    circleView1.CircleContent.ID == circleView2.CircleContent.ID &&
                    circleView2.CircleContent.ID == circleView3.CircleContent.ID)
                {
                    SetScore(circleView1);
                    circleView1.Destroy();
                    circleView2.Destroy();
                    circleView3.Destroy();

                    _currentCircleCount -= _gameConfig.CircleCountForDestroy;

                    columns[x1].Remove(y1);
                    columns[x2].Remove(y2);
                    columns[x3].Remove(y3);
                }
            }
        }

        private void SetScore(CircleView circleView1)
        {
            _scoreData.SetScore(circleView1.CircleContent.Score);
            _gameView.SetScore(_scoreData.Score);
        }

        private bool IsValidIndex(List<TriggerZone> columns, int x, int y)
        {
            return x >= 0 && x < columns.Count && y >= 0 && y < columns[x].CircleViews.Count;
        }
        
        private void SetScore(List<TriggerZone> columns, int i)
        {
            _scoreData.SetScore(columns[0].CircleViews[i].CircleContent.Score);
            _gameView.SetScore(_scoreData.Score);
        }
    }
}
