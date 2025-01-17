﻿using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ScintillaNET
{
    partial class CodeEditor
    {
        /// <summary>
        /// Initialize background selection part of the class.
        /// </summary>
        private void InitializeSelection()
        {
            // setup indicator colors
            Indicators[HighlightIndicatorIndex].Style = IndicatorStyle.StraightBox;
            Indicators[HighlightIndicatorIndex].Under = true;
            Indicators[HighlightIndicatorIndex].ForeColor = Theme.SelectForeColor;
            Indicators[HighlightIndicatorIndex].OutlineAlpha = 100;
            Indicators[HighlightIndicatorIndex].Alpha = 50;
            Indicators[DebugIndicatorIndex].ForeColor = Color.Red;
            Indicators[DebugIndicatorIndex].Style = IndicatorStyle.Squiggle;
            Indicators[DebugHighlight].Style = IndicatorStyle.StraightBox;
            Indicators[DebugHighlight].Under = true;
            Indicators[DebugHighlight].ForeColor = Color.Yellow;
            Indicators[DebugHighlight].OutlineAlpha = 100;
            Indicators[DebugHighlight].Alpha = 50;

            SetSelectionBackColor(true, Theme.SelectBackColor);

            // setup multi line selection
            MultipleSelection = true;
            MouseSelectionRectangularSwitch = true;
            AdditionalSelectionTyping = true;
            VirtualSpaceOptions = VirtualSpace.RectangularSelection;

            // instantiate fields
            IndicatorRanges = Enumerable.Repeat(new List<int[]>(), Indicators.Count).ToArray();
        }

        /// <summary>
        /// Clear all indicators of indicator index.
        /// </summary>
        /// <param name="index">Indicator index.</param>
        public void ClearIndicators(int index)
        {
            // Remove all uses of our indicator
            IndicatorCurrent = index;
            IndicatorClearRange(0, TextLength);
            IndicatorRanges[index].Clear();
        }

        /// <summary>
        /// Add indicators to indicator index.
        /// </summary>
        /// <param name="index">Indicator index.</param>
        /// <param name="ranges">Indicator ranges in the text.</param>
        public void AddIndicators(int index, IEnumerable<int[]> ranges)
        {
            // set active indicator
            IndicatorCurrent = index;
            
            foreach (var range in ranges)
            {
                // add indicator range
                IndicatorRanges[index].Add(range);
                IndicatorFillRange(range[0], range[1] - range[0]);
            }
        }

        /// <summary>
        /// Go to next indicator of indicator index.
        /// </summary>
        /// <param name="index">Indicator index.</param>
        /// <param name="skip">Number of indicator positions to skip.</param>
        public void GotoNextIndicator(int index, int skip = 0)
        {
            GotoNextRange(IndicatorRanges[index], skip);
        }

        /// <summary>
        /// Select (as in select text) all indicators.
        /// </summary>
        /// <param name="index">Indicator index.</param>
        public void SelectIndicators(int index)
        {
            // get current caret position
            var cur = CurrentPosition;

            // get selected word ranges
            var ranges = IndicatorRanges[index];
            var count = ranges.Count();

            // select all word ranges
            ClearSelections();
            foreach (var range in ranges)
                AddSelection(range[0], range[1]);

            // ClearSelections adds a default selection
            // at position 0 which we need to remove
            DropSelection(0);

            // rotate through all selections until we arrive at the original caret position
            for (int i = 0; (cur < CurrentPosition || AnchorPosition < cur) && i < count; i++)
                RotateSelection();
        }

        /// <summary>
        /// Get all words from all selected text ranges.
        /// If a word is only partially selected, the
        /// returned bool value will be 'false'.
        /// </summary>
        /// <returns>Returns a dictionary of all found words
        /// where the keys are the words or partial words
        /// found and the value indicates whether the word is
        /// a whole word.</returns>
        private Dictionary<string, bool> GetWordsFromSelections()
        {
            var words = new Dictionary<string, bool>();

            // highlight all selected text
            foreach (var selection in Selections)
            {
                // text length of selection
                var len = selection.End - selection.Start;
                // if not a selected word
                var word = len == 0 ?
                    // select word at caret position
                    GetWordFromPosition(selection.Caret) :
                    // get selected text
                    GetTextRange(selection.Start, len);

                // trim word to make sure
                // blanks are not selected
                word = word.Trim();

                // do not add empty strings 
                // (GetWordFromPosition can return those)
                if (word.Length == 0)
                    continue;

                // was selection a whole word
                var isWholeWord = len == 0 || IsRangeWord(selection.Start, selection.End);

                // we cannot add the same key twice
                if (words.ContainsKey(word))
                    words[word] |= isWholeWord;
                else
                    words.Add(word, isWholeWord);
            }

            return words;
        }

        /// <summary>
        /// Get the bounding box of the word.
        /// </summary>
        /// <param name="position">Text position</param>
        /// <returns>Returns the bounding box of the word in control coordinates.</returns>
        public Rectangle GetWordBounds(int position)
        {
            var start = WordStartPosition(position, true);
            var style = Styles[GetStyleAt(position)];
            var word = GetWordFromPosition(position);
            var size = TextRenderer.MeasureText(word, new Font(style.Font, style.SizeF));
            return new Rectangle(
                PointXFromPosition(start),
                PointYFromPosition(start),
                size.Width, size.Height);
        }
    }
}
