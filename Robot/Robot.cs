using System;
using System.Collections.Generic;
using Office;

namespace RobotCleaner {
    public class Robot {

        private const char coordinateSeparator = ' ';
        private Dictionary<string, int> Directions { get; set; } = new Dictionary<string, int> ();
        private Graph<OfficeTile> room;
        private List<int> currenActions;
        private int total_actions = 0;
        public List<Coordinate?> CleanedPlaces = new List<Coordinate?> ();
        public Nullable<Coordinate> CurrentPlace;
        public List<Coordinate?> Route = new List<Coordinate?> ();
        public bool IsPlaceCleaned { get; set; }

        public Robot () {

        }

        public Robot (int actions) {
            this.total_actions = actions;
        }

        private void Move (Coordinate nextCoordinate) {

            this.CurrentPlace = IsOutofBounds (nextCoordinate) ? new Nullable<Coordinate> () : nextCoordinate;
        }

        private void CheckCleanFinished (Coordinate? coordinate) {
            if (currenActions.Count.Equals (total_actions)) {
                this.CleanedPlaces.Add (coordinate);
            }
        }

        private void GetNextPlace (Coordinate? coordinate, KeyValuePair<string, int> direction) {
            var newCoordinate = new Coordinate (0, 0);
            for (int i = 0; i < direction.Value; i++) {
                Route.Add (newCoordinate);

            }

        }

        private Coordinate? AddCoordinate (Coordinate? newCoordinate, string direction) {
            CoordinateCalculator.Increase (newCoordinate.Value, direction);
            return newCoordinate;
        }

        private void reset () {
            this.currenActions = new List<int> ();
        }

        public void AddCleaningDirections (string direction) {
            var value = direction.Split (coordinateSeparator);
            Directions.Add (value[0], int.Parse (value[1]));
        }

        public void SetInitialPosition (Coordinate initialCoordinate) {
            this.Move (initialCoordinate);
            this.Route.Add (initialCoordinate);
        }

        public bool IsOutofBounds (Coordinate? coordinate) {
            return !(coordinate.Value.X >= 0 && coordinate.Value.X < this.room.Width && coordinate.Value.Y >= 0 && coordinate.Value.Y < this.room.Height);
        }
        public void Clean () {

            reset ();

            foreach (var coordinate in Route) {

                reset ();
                this.CurrentPlace = coordinate;

                if (!IsOutofBounds (CurrentPlace)) {
                    for (int i = 0; i < total_actions; i++) {
                        this.currenActions.Add (i);
                    }

                    CheckCleanFinished (CurrentPlace);
                }

            }

        }

        private void turnOn (Graph<OfficeTile> room) {
            this.room = room;
        }

        public  void Boot (List<string> directions, int actions, string intitialPostition) {

            turnOn (new Office.OfficeMapGenerator (40, 40).Build ());
            var initialCoordinate = intitialPostition.Split (' ');
            SetInitialPosition (new Office.Coordinate (int.Parse (initialCoordinate[0]), int.Parse (initialCoordinate[1])));
            foreach (var direction in directions) {
                AddCleaningDirections (direction);
            }
            CalculateRoute();
        }

        private void CalculateRoute () {
            if (CurrentPlace.HasValue) {
                foreach (var direction in Directions) {
                    var coordinate = new Coordinate (CurrentPlace.Value.X, CurrentPlace.Value.Y);
                    GetNextPlace (coordinate, direction);
                }
            }
        }

        public string Summary () {
            return $"=> cleaned: {CleanedPlaces.Count.ToString()}";
        }

    }
}