// PdfService.cs
using CustomerApi.Models.Entities;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;

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

                // Add title
                Font titleFont = new Font(Font.FontFamily.HELVETICA, 18, Font.BOLD);
                Paragraph title = new Paragraph("Customer List", titleFont)
                {
                    Alignment = Element.ALIGN_CENTER
                };
                document.Add(title);

                // Add some space before the table
                document.Add(new Chunk("\n"));

                // Create a table with 5 columns
                PdfPTable table = new PdfPTable(5)
                {
                    WidthPercentage = 100
                };

                // Set the width of the first column (Sl No) to be smaller
                float[] columnWidths = new float[] { 0.5f, 2f, 3f, 3f, 2f };
                table.SetWidths(columnWidths);

                // Add header cells to the table
                Font headerFont = new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD);
                table.AddCell(new PdfPCell(new Phrase("Sl No", headerFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
                table.AddCell(new PdfPCell(new Phrase("Name", headerFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
                table.AddCell(new PdfPCell(new Phrase("Email", headerFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
                table.AddCell(new PdfPCell(new Phrase("Address", headerFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
                table.AddCell(new PdfPCell(new Phrase("MobileNo", headerFont)) { HorizontalAlignment = Element.ALIGN_CENTER });

                // Add customer data to the table
                Font cellFont = new Font(Font.FontFamily.HELVETICA, 12);
                BaseColor evenRowColor = new BaseColor(245, 245, 245);  // Lighter gray for even rows
                int slNo = 1;

                foreach (var customer in customers)
                {
                    if (slNo % 2 == 0)
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

                return memoryStream.ToArray();  // Return the PDF as a byte array
            }
        }
        catch (Exception ex)
        {
            // Log the exception (you could log this to a file or a logging service)
            // For now, we're just rethrowing the exception
            throw new Exception("An error occurred while generating the PDF.", ex);
        }
    }
}
