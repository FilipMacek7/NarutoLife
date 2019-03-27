using NarutoLife.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NarutoLife.views.frames
{
    /// <summary>
    /// Interakční logika pro Fightbar.xaml
    /// </summary>
    public partial class NarutoFightbar : Page
    {
        public NarutoFightbar(Character Naruto)
        {
            InitializeComponent();
            decimal decimalhealthbar = (decimal)Naruto.health / (decimal)Naruto.maxhealth * 100;
            healthbar.Value = (int)decimalhealthbar;
            decimal decimalchakrabar = (decimal)Naruto.chakra / (decimal)Naruto.maxchakra * 100;
            chakrabar.Value = (int)decimalchakrabar;
            decimal decimalcombatbar = (decimal)Naruto.combat / (decimal)Naruto.maxcombat * 100;
            combatbar.Value = (int)decimalcombatbar;
        }
    }
}
