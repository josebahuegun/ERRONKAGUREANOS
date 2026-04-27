using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUREANOS_ERRONKA.CODIGO
{
    // : Gailua jarriz herentzia aplikatzen da eta Gailuaren propietateak jasotzen dira, gailua + inpresora kasu hontan
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="GUREANOS_ERRONKA.CODIGO.Gailua" />
    public class Inprimagailua : Gailua
    {
        /// <summary>
        /// The koloretakoa
        /// </summary>
        private bool koloretakoa;
        /// <summary>
        /// The teknologia
        /// </summary>
        private string teknologia;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Inprimagailua"/> is koloretakoa.
        /// </summary>
        /// <value>
        ///   <c>true</c> if koloretakoa; otherwise, <c>false</c>.
        /// </value>
        public bool Koloretakoa { get => koloretakoa; set => koloretakoa = value; }
        /// <summary>
        /// Gets or sets the teknologia.
        /// </summary>
        /// <value>
        /// The teknologia.
        /// </value>
        public string Teknologia { get => teknologia; set => teknologia = value; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Inprimagailua"/> class.
        /// </summary>
        /// <param name="mark">The mark.</param>
        /// <param name="koka">The koka.</param>
        /// <param name="eData">The e data.</param>
        /// <param name="ego">The ego.</param>
        /// <param name="mintt">The mintt.</param>
        /// <param name="kolor">if set to <c>true</c> [kolor].</param>
        /// <param name="tek">The tek.</param>
        public Inprimagailua(string mark, string koka, DateTime eData, string ego, string mintt, bool kolor, string tek)
            : base("Inprimagailua", mark, koka, eData, ego, mintt)
        {
            koloretakoa = kolor;
            teknologia = tek;
        }
    }
}
