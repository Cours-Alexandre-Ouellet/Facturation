namespace Facturation
{
    /// <summary>
    /// Contient l'information sur les taxes versées
    /// pour un produit
    /// </summary>
    public abstract class AbstractTaxes
    {
        /// <summary>
        /// Taux de taxation national en vigueur
        /// </summary>
        public virtual float TauxTaxeNationale { get; protected set; }

        /// <summary>
        /// Taux de taxation local en vigueur
        /// </summary>
        public virtual float TauxTaxeLocale { get; protected set; }

        /// <summary>
        /// Valeur de taxe nationale appliquée sur le montant
        /// </summary>
        public virtual float ValeurTaxeNationale { get; set; }

        /// <summary>
        /// Valeur de taxe locale appliquée sur le montant
        /// </summary>
        public virtual float ValeurTaxeLocale { get; set; }

        /// <summary>
        /// Valeur du code de taxes
        /// </summary>
        public virtual string CodeTaxe { get; protected set; }

        /// <summary>
        /// Crée la base d'un contenu de taxes
        /// </summary>
        /// <param name="codeTaxe">Le code de taxe représenté</param>
        /// <param name="tauxTaxeNational">Le taux de la taxe nationale</param>
        /// <param name="tauxTaxeLocal">Le taux de la taxe locale</param>
        public AbstractTaxes(string codeTaxe, float tauxTaxeNationale, float tauxTaxeLocale)
        {
            CodeTaxe = codeTaxe;
            TauxTaxeNationale = tauxTaxeNationale;
            TauxTaxeLocale = tauxTaxeLocale;
        }

        /// <summary>
        /// Clone l'objet de taxes et retourne la copie
        /// </summary>
        /// <returns>Une copie de l'objet incluant seulement les 
        /// taux de taxes et le code de taxes.</returns>
        public abstract AbstractTaxes Clone();
    }
}
