using System;
using System.Threading.Tasks;

namespace ShadySoft.Blazor.DropDown
{
    public class DropDownManager
    {
        private bool skipNextBlur;
        private readonly string openButtonClass;
        private readonly string closedButtonClass;
        private readonly string openMenuClass;
        private readonly string closedMenuClass;

        public DropDownManager(string openButtonClass = "show", string closedButtonClass = "", string openMenuClass = "show", string closedMenuClass = "")
        {
            this.openButtonClass = openButtonClass;
            this.closedButtonClass = closedButtonClass;
            this.openMenuClass = openMenuClass;
            this.closedMenuClass = closedMenuClass;
        }

        private bool _open;
        public bool Open { 
            get
            {
                return _open;
            }
            private set
            {
                var oldValue = _open;
                _open = value;
                if (oldValue != value)
                    StateChanged.Invoke();
            } 
        }
        public string ButtonClass => Open ? openButtonClass : closedButtonClass;
        public string MenuClass => Open ? openMenuClass : closedMenuClass;

        public void ButtonClicked() => Open = !Open;
        public void MenuClicked() => Open = false;
        public void MenuMouseDown() => skipNextBlur = true;
        public event Func<Task> StateChanged;

        public void ButtonBlur()
        {
            if (!skipNextBlur)
                Open = false;

            skipNextBlur = false;
        }
    }
}
