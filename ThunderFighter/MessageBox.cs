namespace ThunderFighter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class MessageBox : Entity
    {
        private readonly string message;
        private readonly MessageBoxDrawing messageBoxDrawing;
        private readonly MessageBoxTextAlignment messageBoxTextAlignment;

        public MessageBox(
            Field field, 
            string message, 
            MessageBoxDrawing messageBoxDrawing = MessageBoxDrawing.DrawToRight, 
            MessageBoxTextAlignment messageBoxTextAlignment = MessageBoxTextAlignment.Left) 
            : base(field, field.Center, MessageBox.BodyStates(message, messageBoxDrawing, messageBoxTextAlignment), EntityState.Strong)
        {
            this.message = message;
            this.messageBoxDrawing = messageBoxDrawing;
            this.messageBoxTextAlignment = messageBoxTextAlignment;
        }

        private static List<List<Pixel>> BodyStates(
            string message, 
            MessageBoxDrawing messageBoxDrawing, 
            MessageBoxTextAlignment messageBoxTextAlignment)
        {
            List<List<Pixel>> bodyStates = new List<List<Pixel>>();

            char borderChar = '*';
            ConsoleColor borderColor = ConsoleColor.Black;
            ConsoleColor messageColor = ConsoleColor.Red;

            string[] messageLines = message.Split('\n');
            int maxLineLength = messageLines.Select(x => x.Length).Max();

            int textWidth = maxLineLength;
            int textHeight = messageLines.Length;

            int boxWidth = textWidth + 4;
            int boxHeight = textHeight + 2;

            List<Pixel> body = new List<Pixel>();

            for (int i = 0; i < boxWidth; i++)
            {
                body.Add(new Pixel(i, 0, borderChar, borderColor));
            }

            for (int k = 0; k < messageLines.Length; k++)
            {
                string line = messageLines[k];

                body.Add(new Pixel(0, k + 1, borderChar, borderColor));
                body.Add(new Pixel(1, k + 1, ' ', borderColor));

                line = ApplyMessageBoxTextAlignment(messageBoxTextAlignment, textWidth, line);

                for (int i = 0; i < line.Length; i++)
                {
                    body.Add(new Pixel(i + 2, k + 1, line[i], ConsoleColor.Blue));
                }

                body.Add(new Pixel(boxWidth - 2, k + 1, ' ', borderColor));
                body.Add(new Pixel(boxWidth - 1, k + 1, borderChar, borderColor));
            }

            for (int i = 0; i < boxWidth; i++)
            {
                body.Add(new Pixel(i, boxHeight - 1, borderChar, borderColor));
            }

            ApplyMessageBoxDrawing(messageBoxDrawing, boxWidth, boxHeight, body);

            bodyStates.Add(body);

            return bodyStates;
        }

        private static void ApplyMessageBoxDrawing(MessageBoxDrawing messageBoxDrawing, int boxWidth, int boxHeight, List<Pixel> body)
        {
            int xOffset = 0;
            int yOffset = 0;

            if (messageBoxDrawing == MessageBoxDrawing.DrawCentered)
            {
                xOffset = boxWidth / 2;
                yOffset = boxHeight / 2;
            }
            else if (messageBoxDrawing == MessageBoxDrawing.DrawToLeft)
            {
                xOffset = boxWidth;
            }

            foreach (var pixel in body)
            {
                pixel.Coordinate.X -= xOffset;
                pixel.Coordinate.Y -= yOffset;
            }
        }

        private static string ApplyMessageBoxTextAlignment(MessageBoxTextAlignment messageBoxTextAlignment, int textWidth, string line)
        {
            int lineOffsetX = 0;
            if (messageBoxTextAlignment == MessageBoxTextAlignment.Center)
            {
                lineOffsetX = (textWidth - line.Length) / 2;
            }

            for (int i = 0; i < lineOffsetX; i++)
            {
                line = ' ' + line;
            }

            int endWhiteSpacesCount = textWidth - line.Length;
            for (int i = 0; i < endWhiteSpacesCount; i++)
            {
                line = line + ' ';
            }

            return line;
        }
    }
}
