using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UnitTestPlugin.View {

    class CustomProgressBar : ProgressBar {

        private SolidBrush foregroundBrush;

        public CustomProgressBar() {
            this.SetStyle( ControlStyles.UserPaint , true );
        }

        protected override void OnPaintBackground( PaintEventArgs e ) {

        }

        protected override void OnPaint( PaintEventArgs e ) {
            foregroundBrush = new SolidBrush( this.ForeColor );

            Rectangle drawArea = GetDrawArea();

            if ( ProgressBarRenderer.IsSupported )
                ProgressBarRenderer.DrawHorizontalBar( e.Graphics , drawArea );
                
            drawArea.Width = ( int ) ( drawArea.Width * ( ( double ) Value / Maximum ) ) - 4;
            drawArea.Height = drawArea.Height - 4;

            e.Graphics.FillRectangle( foregroundBrush , 2 , 2 , drawArea.Width , drawArea.Height );
        }

        private Rectangle GetDrawArea() {
            return new Rectangle( 0 , 0 , this.Width , this.Height );
        }
    }
}
