using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPointUpdate {

    void IAddPoints(int PointsAmount);
    void ISetPoints(int PointsAmount);
    void ISetPointMulti(int MultiAmount, int Duration);
    int IGetPoints();
}
