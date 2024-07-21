using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Hospital.App
{
    [Serializable]
    public class ObDesign
    {
        ActionRec m_Action;
        public ActionRec _Action { get { return m_Action; } set { m_Action = value; } }
        string _Ma, _Ten;
        int _Loai = -1;
        object _OBJ;
        public string Ma { get { return _Ma; } set { _Ma = value; } }
        public string Ten { get { return _Ten; } set { _Ten = value; } }
        public int Loai { get { return _Loai; } set { _Loai = value; } }
        public object OBJ { get { return _OBJ; } set { _OBJ = value; } }
        public ObDesign()
        {
            _Ma = "";
            _Ten = "";
            _OBJ = null;
            m_Action = ActionRec.None;
        }
        public ObDesign(ObDesign cls)
        {
            _Ma = cls.Ma;
            _Ten = cls.Ten;
            _Loai = cls.Loai;
            _OBJ = cls.OBJ;
            m_Action = cls._Action;
        }
    }
}
