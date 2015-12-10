﻿namespace Workflow.Reporting.Entities
{
    public class InvoiceTransactionSummary
    {
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public double Price { get; set; }
        public int QuantityUnit { get; set; }
        public int Vat { get; set; }
    }
}