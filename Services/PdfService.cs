using CustomerApi.Models.Entities;
using iTextSharp.text;
using iTextSharp.text.pdf;

public class PdfService
{
    public byte[] GenerateCustomerPdf(List<CustomerMaster> customers)
    {
        try
        {
            using (var memoryStream = new MemoryStream())
            {
                Document document = new Document(PageSize.A4);
                PdfWriter.GetInstance(document, memoryStream);
                document.Open();

                Font titleFont = new Font(Font.FontFamily.HELVETICA, 18, Font.BOLD);
                Paragraph title = new Paragraph("Customer List", titleFont)
                {
                    Alignment = Element.ALIGN_CENTER
                };
                document.Add(title);

                document.Add(new Chunk("\n"));

                PdfPTable table = new PdfPTable(5)
                {
                    WidthPercentage = 100
                };

                float[] columnWidths = new float[] { 0.5f, 2f, 3f, 3f, 2f };
                table.SetWidths(columnWidths);

                Font headerFont = new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD);
                table.AddCell(new PdfPCell(new Phrase("Sl No", headerFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
                table.AddCell(new PdfPCell(new Phrase("Name", headerFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
                table.AddCell(new PdfPCell(new Phrase("Email", headerFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
                table.AddCell(new PdfPCell(new Phrase("Address", headerFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
                table.AddCell(new PdfPCell(new Phrase("MobileNo", headerFont)) { HorizontalAlignment = Element.ALIGN_CENTER });

                Font cellFont = new Font(Font.FontFamily.HELVETICA, 12);
                BaseColor evenRowColor = new BaseColor(245, 245, 245);
                int slNo = 1;

                foreach (var customer in customers)
                {
                    if (slNo % 2 != 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(slNo.ToString(), cellFont)) { BackgroundColor = evenRowColor, HorizontalAlignment = Element.ALIGN_CENTER });
                        table.AddCell(new PdfPCell(new Phrase(customer.Name, cellFont)) { BackgroundColor = evenRowColor });
                        table.AddCell(new PdfPCell(new Phrase(customer.Email, cellFont)) { BackgroundColor = evenRowColor });
                        table.AddCell(new PdfPCell(new Phrase(customer.Address, cellFont)) { BackgroundColor = evenRowColor });
                        table.AddCell(new PdfPCell(new Phrase(customer.MobileNo, cellFont)) { BackgroundColor = evenRowColor });
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase(slNo.ToString(), cellFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
                        table.AddCell(new PdfPCell(new Phrase(customer.Name, cellFont)));
                        table.AddCell(new PdfPCell(new Phrase(customer.Email, cellFont)));
                        table.AddCell(new PdfPCell(new Phrase(customer.Address, cellFont)));
                        table.AddCell(new PdfPCell(new Phrase(customer.MobileNo, cellFont)));
                    }

                    slNo++;
                }

                document.Add(table);
                document.Close();

                return memoryStream.ToArray();
            }
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while generating the PDF.", ex);
        }
    }
}
