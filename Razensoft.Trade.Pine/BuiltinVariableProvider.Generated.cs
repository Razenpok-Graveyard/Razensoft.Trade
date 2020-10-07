using System;

namespace Razensoft.Trade.Pine
{
    public abstract partial class BuiltinVariableProvider
    {
        /// <summary>
        /// Accumulation/distribution index.
        /// </summary>
        public virtual PineSeries<float> accdist => throw new NotImplementedException();
        /// <summary>
        /// Constant for dividends adjustment type (dividends adjustment is
        /// applied).
        /// </summary>
        public virtual string adjustment__dividends => throw new NotImplementedException();
        /// <summary>
        /// Constant for none adjustment type (no adjustment is applied).
        /// </summary>
        public virtual string adjustment__none => throw new NotImplementedException();
        /// <summary>
        /// Constant for splits adjustment type (splits adjustment is applied).
        /// </summary>
        public virtual string adjustment__splits => throw new NotImplementedException();
        /// <summary>
        /// Current bar index. Numbering is zero-based, index of the first bar is
        /// 0.
        /// </summary>
        public virtual PineSeries<long> bar_index => throw new NotImplementedException();
        /// <summary>
        /// Merge strategy for requested data. Data is merged continuously without
        /// gaps, all the gaps are filled with the previous nearest existing
        /// value.
        /// </summary>
        public virtual bool barmerge__gaps_off => throw new NotImplementedException();
        /// <summary>
        /// Merge strategy for requested data. Data is merged with possible gaps
        /// (na values).
        /// </summary>
        public virtual bool barmerge__gaps_on => throw new NotImplementedException();
        /// <summary>
        /// Merge strategy for the requested data position. Requested barset is
        /// merged with current barset in the order of sorting bars by their close
        /// time. This merge strategy disables effect of getting data from
        /// "future" on calculation on history.
        /// </summary>
        public virtual bool barmerge__lookahead_off => throw new NotImplementedException();
        /// <summary>
        /// Merge strategy for the requested data position. Requested barset is
        /// merged with current barset in the order of sorting bars by their
        /// opening time. This merge strategy can lead to undesirable effect of
        /// getting data from "future" on calculation on history. This is
        /// unacceptable in backtesting strategies, but can be useful in
        /// indicators.
        /// </summary>
        public virtual bool barmerge__lookahead_on => throw new NotImplementedException();
        /// <summary>
        /// Returns true if the script is calculating the last (closing) update of
        /// the current bar. The next script calculation will be on the new bar
        /// data.
        /// </summary>
        public virtual PineSeries<bool> barstate__isconfirmed => throw new NotImplementedException();
        /// <summary>
        /// Returns true if current bar is first bar in barset, false otherwise.
        /// </summary>
        public virtual PineSeries<bool> barstate__isfirst => throw new NotImplementedException();
        /// <summary>
        /// Returns true if current bar is a historical bar, false otherwise.
        /// </summary>
        public virtual PineSeries<bool> barstate__ishistory => throw new NotImplementedException();
        /// <summary>
        /// Returns true if current bar is the last bar in barset, false
        /// otherwise. This condition is true for all real-time bars in barset.
        /// </summary>
        public virtual PineSeries<bool> barstate__islast => throw new NotImplementedException();
        /// <summary>
        /// Returns true if script is currently calculating on new bar, false
        /// otherwise. This variable is true when calculating on historical bars
        /// or on first update of a newly generated real-time bar.
        /// </summary>
        public virtual PineSeries<bool> barstate__isnew => throw new NotImplementedException();
        /// <summary>
        /// Returns true if current bar is a real-time bar, false otherwise.
        /// </summary>
        public virtual PineSeries<bool> barstate__isrealtime => throw new NotImplementedException();
        /// <summary>
        /// Current close price.
        /// </summary>
        public virtual PineSeries<float> close => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for #00BCD4 color.
        /// </summary>
        public virtual PineColor color__aqua => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for #363A45 color.
        /// </summary>
        public virtual PineColor color__black => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for #2196F3 color.
        /// </summary>
        public virtual PineColor color__blue => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for #E040FB color.
        /// </summary>
        public virtual PineColor color__fuchsia => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for #787B86 color.
        /// </summary>
        public virtual PineColor color__gray => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for #4CAF50 color.
        /// </summary>
        public virtual PineColor color__green => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for #00E676 color.
        /// </summary>
        public virtual PineColor color__lime => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for #880E4F color.
        /// </summary>
        public virtual PineColor color__maroon => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for #311B92 color.
        /// </summary>
        public virtual PineColor color__navy => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for #808000 color.
        /// </summary>
        public virtual PineColor color__olive => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for #FF9800 color.
        /// </summary>
        public virtual PineColor color__orange => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for #9C27B0 color.
        /// </summary>
        public virtual PineColor color__purple => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for #FF5252 color.
        /// </summary>
        public virtual PineColor color__red => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for #B2B5BE color.
        /// </summary>
        public virtual PineColor color__silver => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for #00897B color.
        /// </summary>
        public virtual PineColor color__teal => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for #FFFFFF color.
        /// </summary>
        public virtual PineColor color__white => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for #FFEB3B color.
        /// </summary>
        public virtual PineColor color__yellow => throw new NotImplementedException();
        /// <summary>
        /// Australian dollar.
        /// </summary>
        public virtual string currency__AUD => throw new NotImplementedException();
        /// <summary>
        /// Canadian dollar.
        /// </summary>
        public virtual string currency__CAD => throw new NotImplementedException();
        /// <summary>
        /// Swiss franc.
        /// </summary>
        public virtual string currency__CHF => throw new NotImplementedException();
        /// <summary>
        /// Euro.
        /// </summary>
        public virtual string currency__EUR => throw new NotImplementedException();
        /// <summary>
        /// Pound sterling.
        /// </summary>
        public virtual string currency__GBP => throw new NotImplementedException();
        /// <summary>
        /// Hong Kong dollar.
        /// </summary>
        public virtual string currency__HKD => throw new NotImplementedException();
        /// <summary>
        /// Japanese yen.
        /// </summary>
        public virtual string currency__JPY => throw new NotImplementedException();
        /// <summary>
        /// Norwegian krone.
        /// </summary>
        public virtual string currency__NOK => throw new NotImplementedException();
        /// <summary>
        /// Unspecified currency.
        /// </summary>
        public virtual string currency__NONE => throw new NotImplementedException();
        /// <summary>
        /// New Zealand dollar.
        /// </summary>
        public virtual string currency__NZD => throw new NotImplementedException();
        /// <summary>
        /// Russian ruble.
        /// </summary>
        public virtual string currency__RUB => throw new NotImplementedException();
        /// <summary>
        /// Swedish krona.
        /// </summary>
        public virtual string currency__SEK => throw new NotImplementedException();
        /// <summary>
        /// Singapore dollar.
        /// </summary>
        public virtual string currency__SGD => throw new NotImplementedException();
        /// <summary>
        /// Turkish lira.
        /// </summary>
        public virtual string currency__TRY => throw new NotImplementedException();
        /// <summary>
        /// United States dollar.
        /// </summary>
        public virtual string currency__USD => throw new NotImplementedException();
        /// <summary>
        /// South African rand.
        /// </summary>
        public virtual string currency__ZAR => throw new NotImplementedException();
        /// <summary>
        /// Date of current bar time in exchange timezone.
        /// </summary>
        public virtual PineSeries<long> dayofmonth => throw new NotImplementedException();
        /// <summary>
        /// Day of week for current bar time in exchange timezone.
        /// </summary>
        public virtual PineSeries<long> dayofweek => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for return value of dayofweek function and value
        /// of dayofweek variable.
        /// </summary>
        public virtual long dayofweek__friday => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for return value of dayofweek function and value
        /// of dayofweek variable.
        /// </summary>
        public virtual long dayofweek__monday => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for return value of dayofweek function and value
        /// of dayofweek variable.
        /// </summary>
        public virtual long dayofweek__saturday => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for return value of dayofweek function and value
        /// of dayofweek variable.
        /// </summary>
        public virtual long dayofweek__sunday => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for return value of dayofweek function and value
        /// of dayofweek variable.
        /// </summary>
        public virtual long dayofweek__thursday => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for return value of dayofweek function and value
        /// of dayofweek variable.
        /// </summary>
        public virtual long dayofweek__tuesday => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for return value of dayofweek function and value
        /// of dayofweek variable.
        /// </summary>
        public virtual long dayofweek__wednesday => throw new NotImplementedException();
        /// <summary>
        /// A named constant that specifies where the plot is displayed. Display
        /// everywhere.
        /// </summary>
        public virtual long display__all => throw new NotImplementedException();
        /// <summary>
        /// A named constant that specifies where the plot is displayed. Display
        /// nowhere. Available in alert template message
        /// </summary>
        public virtual long display__none => throw new NotImplementedException();
        /// <summary>
        /// A named constant for line.new and line.set_extend functions
        /// </summary>
        public virtual string extend__both => throw new NotImplementedException();
        /// <summary>
        /// A named constant for line.new and line.set_extend functions
        /// </summary>
        public virtual string extend__left => throw new NotImplementedException();
        /// <summary>
        /// A named constant for line.new and line.set_extend functions
        /// </summary>
        public virtual string extend__none => throw new NotImplementedException();
        /// <summary>
        /// A named constant for line.new and line.set_extend functions
        /// </summary>
        public virtual string extend__right => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for selecting the formatting of the script output
        /// values from the parent series in the study function.
        /// </summary>
        public virtual string format__inherit => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for selecting the formatting of the script output
        /// values as prices in the study function.
        /// </summary>
        public virtual string format__price => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for selecting the formatting of the script output
        /// values as volume in the study function, e.g. '5183' will be formatted
        /// as '5.183K'.
        /// </summary>
        public virtual string format__volume => throw new NotImplementedException();
        /// <summary>
        /// Current high price.
        /// </summary>
        public virtual PineSeries<float> high => throw new NotImplementedException();
        /// <summary>
        /// Is a shortcut for (high + low)/2
        /// </summary>
        public virtual PineSeries<float> hl2 => throw new NotImplementedException();
        /// <summary>
        /// Is a shortcut for (high + low + close)/3
        /// </summary>
        public virtual PineSeries<float> hlc3 => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for dashed linestyle of hline function.
        /// </summary>
        public virtual long hline__style_dashed => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for dotted linestyle of hline function.
        /// </summary>
        public virtual long hline__style_dotted => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for solid linestyle of hline function.
        /// </summary>
        public virtual long hline__style_solid => throw new NotImplementedException();
        /// <summary>
        /// Current bar hour in exchange timezone.
        /// </summary>
        public virtual PineSeries<long> hour => throw new NotImplementedException();
        /// <summary>
        /// Intraday Intensity Index
        /// </summary>
        public virtual PineSeries<float> iii => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for bool input type of input function.
        /// </summary>
        public virtual string input__bool => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for color input type of input function.
        /// </summary>
        public virtual string input__color => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for float input type of input function.
        /// </summary>
        public virtual string input__float => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for integer input type of input function.
        /// </summary>
        public virtual string input__integer => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for resolution input type of input function.
        /// </summary>
        public virtual string input__resolution => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for session input type of input function.
        /// </summary>
        public virtual string input__session => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for source input type of input function.
        /// </summary>
        public virtual string input__source => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for string input type of input function.
        /// </summary>
        public virtual string input__string => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for symbol input type of input function.
        /// </summary>
        public virtual string input__symbol => throw new NotImplementedException();
        /// <summary>
        /// Label style for label.new and label.set_style functions
        /// </summary>
        public virtual string label__style_arrowdown => throw new NotImplementedException();
        /// <summary>
        /// Label style for label.new and label.set_style functions
        /// </summary>
        public virtual string label__style_arrowup => throw new NotImplementedException();
        /// <summary>
        /// Label style for label.new and label.set_style functions
        /// </summary>
        public virtual string label__style_circle => throw new NotImplementedException();
        /// <summary>
        /// Label style for label.new and label.set_style functions
        /// </summary>
        public virtual string label__style_cross => throw new NotImplementedException();
        /// <summary>
        /// Label style for label.new and label.set_style functions
        /// </summary>
        public virtual string label__style_diamond => throw new NotImplementedException();
        /// <summary>
        /// Label style for label.new and label.set_style functions
        /// </summary>
        public virtual string label__style_flag => throw new NotImplementedException();
        /// <summary>
        /// Label style for label.new and label.set_style functions
        /// </summary>
        public virtual string label__style_label_center => throw new NotImplementedException();
        /// <summary>
        /// Label style for label.new and label.set_style functions
        /// </summary>
        public virtual string label__style_label_down => throw new NotImplementedException();
        /// <summary>
        /// Label style for label.new and label.set_style functions
        /// </summary>
        public virtual string label__style_label_left => throw new NotImplementedException();
        /// <summary>
        /// Label style for label.new and label.set_style functions
        /// </summary>
        public virtual string label__style_label_lower_left => throw new NotImplementedException();
        /// <summary>
        /// Label style for label.new and label.set_style functions
        /// </summary>
        public virtual string label__style_label_lower_right => throw new NotImplementedException();
        /// <summary>
        /// Label style for label.new and label.set_style functions
        /// </summary>
        public virtual string label__style_label_right => throw new NotImplementedException();
        /// <summary>
        /// Label style for label.new and label.set_style functions
        /// </summary>
        public virtual string label__style_label_up => throw new NotImplementedException();
        /// <summary>
        /// Label style for label.new and label.set_style functions
        /// </summary>
        public virtual string label__style_label_upper_left => throw new NotImplementedException();
        /// <summary>
        /// Label style for label.new and label.set_style functions
        /// </summary>
        public virtual string label__style_label_upper_right => throw new NotImplementedException();
        /// <summary>
        /// Label style for label.new and label.set_style functions
        /// </summary>
        public virtual string label__style_none => throw new NotImplementedException();
        /// <summary>
        /// Label style for label.new and label.set_style functions
        /// </summary>
        public virtual string label__style_square => throw new NotImplementedException();
        /// <summary>
        /// Label style for label.new and label.set_style functions
        /// </summary>
        public virtual string label__style_triangledown => throw new NotImplementedException();
        /// <summary>
        /// Label style for label.new and label.set_style functions
        /// </summary>
        public virtual string label__style_triangleup => throw new NotImplementedException();
        /// <summary>
        /// Label style for label.new and label.set_style functions
        /// </summary>
        public virtual string label__style_xcross => throw new NotImplementedException();
        /// <summary>
        /// Line style for line.new and line.set_style functions. Solid line with
        /// arrows on both points
        /// </summary>
        public virtual string line__style_arrow_both => throw new NotImplementedException();
        /// <summary>
        /// Line style for line.new and line.set_style functions. Solid line with
        /// arrow on the first point
        /// </summary>
        public virtual string line__style_arrow_left => throw new NotImplementedException();
        /// <summary>
        /// Line style for line.new and line.set_style functions. Solid line with
        /// arrow on the second point
        /// </summary>
        public virtual string line__style_arrow_right => throw new NotImplementedException();
        /// <summary>
        /// Line style for line.new and line.set_style functions
        /// </summary>
        public virtual string line__style_dashed => throw new NotImplementedException();
        /// <summary>
        /// Line style for line.new and line.set_style functions
        /// </summary>
        public virtual string line__style_dotted => throw new NotImplementedException();
        /// <summary>
        /// Line style for line.new and line.set_style functions
        /// </summary>
        public virtual string line__style_solid => throw new NotImplementedException();
        /// <summary>
        /// Location value for plotshape, plotchar functions. Shape is plotted
        /// above main series bars.
        /// </summary>
        public virtual string location__abovebar => throw new NotImplementedException();
        /// <summary>
        /// Location value for plotshape, plotchar functions. Shape is plotted on
        /// chart using indicator value as a price coordinate.
        /// </summary>
        public virtual string location__absolute => throw new NotImplementedException();
        /// <summary>
        /// Location value for plotshape, plotchar functions. Shape is plotted
        /// below main series bars.
        /// </summary>
        public virtual string location__belowbar => throw new NotImplementedException();
        /// <summary>
        /// Location value for plotshape, plotchar functions. Shape is plotted
        /// near the bottom chart border.
        /// </summary>
        public virtual string location__bottom => throw new NotImplementedException();
        /// <summary>
        /// Location value for plotshape, plotchar functions. Shape is plotted
        /// near the top chart border.
        /// </summary>
        public virtual string location__top => throw new NotImplementedException();
        /// <summary>
        /// Current low price.
        /// </summary>
        public virtual PineSeries<float> low => throw new NotImplementedException();
        /// <summary>
        /// Current bar minute in exchange timezone.
        /// </summary>
        public virtual PineSeries<long> minute => throw new NotImplementedException();
        /// <summary>
        /// Current bar month in exchange timezone.
        /// </summary>
        public virtual PineSeries<long> month => throw new NotImplementedException();
        /// <summary>
        /// Double.NaN value (Not a Number).
        /// </summary>
        public virtual PineNA na => throw new NotImplementedException();
        /// <summary>
        /// Negative Volume Index
        /// </summary>
        public virtual PineSeries<float> nvi => throw new NotImplementedException();
        /// <summary>
        /// On Balance Volume
        /// </summary>
        public virtual PineSeries<float> obv => throw new NotImplementedException();
        /// <summary>
        /// Is a shortcut for (open + high + low + close)/4
        /// </summary>
        public virtual PineSeries<float> ohlc4 => throw new NotImplementedException();
        /// <summary>
        /// Current open price.
        /// </summary>
        public virtual PineSeries<float> open => throw new NotImplementedException();
        /// <summary>
        /// Determines the sort order of the array from the smallest to the
        /// largest value.
        /// </summary>
        public virtual bool order__ascending => throw new NotImplementedException();
        /// <summary>
        /// Determines the sort order of the array from the largest to the
        /// smallest value.
        /// </summary>
        public virtual bool order__descending => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for area style of plot function.
        /// </summary>
        public virtual long plot__style_area => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for area style of plot function. Same as area but
        /// doesn't fill the breaks (gaps) in data.
        /// </summary>
        public virtual long plot__style_areabr => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for circles style of plot function.
        /// </summary>
        public virtual long plot__style_circles => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for columns style of plot function.
        /// </summary>
        public virtual long plot__style_columns => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for cross style of plot function.
        /// </summary>
        public virtual long plot__style_cross => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for histogram style of plot function.
        /// </summary>
        public virtual long plot__style_histogram => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for line style of plot function.
        /// </summary>
        public virtual long plot__style_line => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for line style of plot function. Same as line but
        /// doesn't fill the breaks (gaps) in data.
        /// </summary>
        public virtual long plot__style_linebr => throw new NotImplementedException();
        /// <summary>
        /// Is a named constant for stepline style of plot function.
        /// </summary>
        public virtual long plot__style_stepline => throw new NotImplementedException();
        /// <summary>
        /// Positive Volume Index
        /// </summary>
        public virtual PineSeries<float> pvi => throw new NotImplementedException();
        /// <summary>
        /// Price-Volume Trend
        /// </summary>
        public virtual PineSeries<float> pvt => throw new NotImplementedException();
        /// <summary>
        /// Scale value for study function. Study is added to the left price
        /// scale.
        /// </summary>
        public virtual long scale__left => throw new NotImplementedException();
        /// <summary>
        /// Scale value for study function. Study is added in 'No Scale' mode. Can
        /// be used only with 'overlay=true'.
        /// </summary>
        public virtual long scale__none => throw new NotImplementedException();
        /// <summary>
        /// Scale value for study function. Study is added to the right price
        /// scale.
        /// </summary>
        public virtual long scale__right => throw new NotImplementedException();
        /// <summary>
        /// Current bar second in exchange timezone.
        /// </summary>
        public virtual PineSeries<long> second => throw new NotImplementedException();
        /// <summary>
        /// Constant for extended session type (with extended hours data).
        /// </summary>
        public virtual string session__extended => throw new NotImplementedException();
        /// <summary>
        /// Constant for regular session type (no extended hours data).
        /// </summary>
        public virtual string session__regular => throw new NotImplementedException();
        /// <summary>
        /// Shape style for plotshape function.
        /// </summary>
        public virtual string shape__arrowdown => throw new NotImplementedException();
        /// <summary>
        /// Shape style for plotshape function.
        /// </summary>
        public virtual string shape__arrowup => throw new NotImplementedException();
        /// <summary>
        /// Shape style for plotshape function.
        /// </summary>
        public virtual string shape__circle => throw new NotImplementedException();
        /// <summary>
        /// Shape style for plotshape function.
        /// </summary>
        public virtual string shape__cross => throw new NotImplementedException();
        /// <summary>
        /// Shape style for plotshape function.
        /// </summary>
        public virtual string shape__diamond => throw new NotImplementedException();
        /// <summary>
        /// Shape style for plotshape function.
        /// </summary>
        public virtual string shape__flag => throw new NotImplementedException();
        /// <summary>
        /// Shape style for plotshape function.
        /// </summary>
        public virtual string shape__labeldown => throw new NotImplementedException();
        /// <summary>
        /// Shape style for plotshape function.
        /// </summary>
        public virtual string shape__labelup => throw new NotImplementedException();
        /// <summary>
        /// Shape style for plotshape function.
        /// </summary>
        public virtual string shape__square => throw new NotImplementedException();
        /// <summary>
        /// Shape style for plotshape function.
        /// </summary>
        public virtual string shape__triangledown => throw new NotImplementedException();
        /// <summary>
        /// Shape style for plotshape function.
        /// </summary>
        public virtual string shape__triangleup => throw new NotImplementedException();
        /// <summary>
        /// Shape style for plotshape function.
        /// </summary>
        public virtual string shape__xcross => throw new NotImplementedException();
        /// <summary>
        /// Size value for plotshape, plotchar functions. The size of the shape
        /// automatically adapts to the size of the bars.
        /// </summary>
        public virtual string size__auto => throw new NotImplementedException();
        /// <summary>
        /// Size value for plotshape, plotchar functions. The size of the shape
        /// constantly huge.
        /// </summary>
        public virtual string size__huge => throw new NotImplementedException();
        /// <summary>
        /// Size value for plotshape, plotchar functions. The size of the shape
        /// constantly large.
        /// </summary>
        public virtual string size__large => throw new NotImplementedException();
        /// <summary>
        /// Size value for plotshape, plotchar functions. The size of the shape
        /// constantly normal.
        /// </summary>
        public virtual string size__normal => throw new NotImplementedException();
        /// <summary>
        /// Size value for plotshape, plotchar functions. The size of the shape
        /// constantly small.
        /// </summary>
        public virtual string size__small => throw new NotImplementedException();
        /// <summary>
        /// Size value for plotshape, plotchar functions. The size of the shape
        /// constantly tiny.
        /// </summary>
        public virtual string size__tiny => throw new NotImplementedException();
        /// <summary>
        /// If the number of contracts/shares/lots/units to buy/sell is not
        /// specified for strategy.entry or strategy.order commands (or 'NaN' is
        /// specified), then strategy will calculate the quantity to buy/sell at
        /// close of current bar using the amount of money specified in the
        /// 'default_qty_value'.
        /// </summary>
        public virtual string strategy__cash => throw new NotImplementedException();
        /// <summary>
        /// Number of trades, which were closed for the whole trading interval.
        /// </summary>
        public virtual PineSeries<long> strategy__closedtrades => throw new NotImplementedException();
        /// <summary>
        /// Commission type for an order. Money displayed in the account currency
        /// per contract.
        /// </summary>
        public virtual string strategy__commission__cash_per_contract => throw new NotImplementedException();
        /// <summary>
        /// Commission type for an order. Money displayed in the account currency
        /// per order.
        /// </summary>
        public virtual string strategy__commission__cash_per_order => throw new NotImplementedException();
        /// <summary>
        /// Commission type for an order. A percentage of the cash volume of
        /// order.
        /// </summary>
        public virtual string strategy__commission__percent => throw new NotImplementedException();
        /// <summary>
        /// It allows strategy to open both long and short positions.
        /// </summary>
        public virtual string strategy__direction__all => throw new NotImplementedException();
        /// <summary>
        /// It allows strategy to open only long positions.
        /// </summary>
        public virtual string strategy__direction__long => throw new NotImplementedException();
        /// <summary>
        /// It allows strategy to open only short positions.
        /// </summary>
        public virtual string strategy__direction__short => throw new NotImplementedException();
        /// <summary>
        /// Current equity ( strategy.initial_capital + strategy.netprofit +
        /// strategy.openprofit ).
        /// </summary>
        public virtual PineSeries<float> strategy__equity => throw new NotImplementedException();
        /// <summary>
        /// Number of breakeven trades for the whole trading interval.
        /// </summary>
        public virtual PineSeries<long> strategy__eventrades => throw new NotImplementedException();
        /// <summary>
        /// If the number of contracts/shares/lots/units to buy/sell is not
        /// specified for strategy.entry or strategy.order commands (or 'NaN' is
        /// specified), then the 'default_qty_value' is used to define the
        /// quantity.
        /// </summary>
        public virtual string strategy__fixed => throw new NotImplementedException();
        /// <summary>
        /// Total currency value of all completed losing trades.
        /// </summary>
        public virtual PineSeries<float> strategy__grossloss => throw new NotImplementedException();
        /// <summary>
        /// Total currency value of all completed winning trades.
        /// </summary>
        public virtual PineSeries<float> strategy__grossprofit => throw new NotImplementedException();
        /// <summary>
        /// The amount of initial capital set in the strategy properties.
        /// </summary>
        public virtual PineSeries<float> strategy__initial_capital => throw new NotImplementedException();
        /// <summary>
        /// Long position entry.
        /// </summary>
        public virtual bool strategy__long => throw new NotImplementedException();
        /// <summary>
        /// Number of unprofitable trades for the whole trading interval.
        /// </summary>
        public virtual PineSeries<long> strategy__losstrades => throw new NotImplementedException();
        /// <summary>
        /// Maximum number of contracts/shares/lots/units in one trade for the
        /// whole trading interval.
        /// </summary>
        public virtual PineSeries<float> strategy__max_contracts_held_all => throw new NotImplementedException();
        /// <summary>
        /// Maximum number of contracts/shares/lots/units in one long trade for
        /// the whole trading interval.
        /// </summary>
        public virtual PineSeries<float> strategy__max_contracts_held_long => throw new NotImplementedException();
        /// <summary>
        /// Maximum number of contracts/shares/lots/units in one short trade for
        /// the whole trading interval.
        /// </summary>
        public virtual PineSeries<float> strategy__max_contracts_held_short => throw new NotImplementedException();
        /// <summary>
        /// Maximum equity drawdown value for the whole trading interval.
        /// </summary>
        public virtual PineSeries<float> strategy__max_drawdown => throw new NotImplementedException();
        /// <summary>
        /// Total currency value of all completed trades.
        /// </summary>
        public virtual PineSeries<float> strategy__netprofit => throw new NotImplementedException();
        /// <summary>
        /// OCA type value for strategy's functions. The parameter determines that
        /// an order should belong to an OCO group, where as soon as an order is
        /// filled, all other orders of the same group are cancelled. Note: if
        /// more than 1 guaranteed-to-be-executed orders of the same OCA group are
        /// placed at once, all those orders are filled.
        /// </summary>
        public virtual string strategy__oca__cancel => throw new NotImplementedException();
        /// <summary>
        /// OCA type value for strategy's functions. The parameter determines that
        /// an order should not belong to any particular OCO group.
        /// </summary>
        public virtual string strategy__oca__none => throw new NotImplementedException();
        /// <summary>
        /// OCA type value for strategy's functions. The parameter determines that
        /// an order should belong to an OCO group, where if X number of contracts
        /// of an order is filled, number of contracts for each other order of the
        /// same OCO group is decreased by X. Note: if more than 1
        /// guaranteed-to-be-executed orders of the same OCA group are placed at
        /// once, all those orders are filled.
        /// </summary>
        public virtual string strategy__oca__reduce => throw new NotImplementedException();
        /// <summary>
        /// Current unrealized profit or loss for the open position.
        /// </summary>
        public virtual PineSeries<float> strategy__openprofit => throw new NotImplementedException();
        /// <summary>
        /// Number of market position entries, which were not closed and remain
        /// opened. If there is no open market position, 0 is returned.
        /// </summary>
        public virtual PineSeries<long> strategy__opentrades => throw new NotImplementedException();
        /// <summary>
        /// If the number of contracts/shares/lots/units to buy/sell is not
        /// specified for strategy.entry or strategy.order commands (or 'NaN' is
        /// specified), then strategy will calculate the quantity to buy/sell at
        /// close of current bar using the amount of money specified by the
        /// 'default_qty_value' in % from current strategy.equity (in the range
        /// from 0 to 100).
        /// </summary>
        public virtual string strategy__percent_of_equity => throw new NotImplementedException();
        /// <summary>
        /// Average entry price of current market position. If the market position
        /// is flat, 'NaN' is returned.
        /// </summary>
        public virtual PineSeries<float> strategy__position_avg_price => throw new NotImplementedException();
        /// <summary>
        /// Name of the order that initially opened current market position.
        /// </summary>
        public virtual string strategy__position_entry_name => throw new NotImplementedException();
        /// <summary>
        /// Direction and size of the current market position. If the value is
        /// &gt; 0, the market position is long. If the value is &lt; 0, the
        /// market position is short. The absolute value is the number of
        /// contracts/shares/lots/units in trade (position size).
        /// </summary>
        public virtual PineSeries<float> strategy__position_size => throw new NotImplementedException();
        /// <summary>
        /// Short position entry.
        /// </summary>
        public virtual bool strategy__short => throw new NotImplementedException();
        /// <summary>
        /// Number of profitable trades for the whole trading interval.
        /// </summary>
        public virtual PineSeries<long> strategy__wintrades => throw new NotImplementedException();
        /// <summary>
        /// Base currency for the symbol. For the symbol 'BTCUSD' returns 'BTC'.
        /// </summary>
        public virtual string syminfo__basecurrency => throw new NotImplementedException();
        /// <summary>
        /// Currency for the current symbol. Returns currency code: 'USD', 'EUR',
        /// etc.
        /// </summary>
        public virtual string syminfo__currency => throw new NotImplementedException();
        /// <summary>
        /// Description for the current symbol.
        /// </summary>
        public virtual string syminfo__description => throw new NotImplementedException();
        /// <summary>
        /// Min tick value for the current symbol.
        /// </summary>
        public virtual float syminfo__mintick => throw new NotImplementedException();
        /// <summary>
        /// Point value for the current symbol.
        /// </summary>
        public virtual float syminfo__pointvalue => throw new NotImplementedException();
        /// <summary>
        /// Prefix of current symbol name (i.e. for 'CME_EOD:TICKER' prefix is
        /// 'CME_EOD').
        /// </summary>
        public virtual string syminfo__prefix => throw new NotImplementedException();
        /// <summary>
        /// Root for derivatives like futures contract. For other symbols returns
        /// the same value as syminfo.ticker.
        /// </summary>
        public virtual string syminfo__root => throw new NotImplementedException();
        /// <summary>
        /// Session type of the chart main series. Possible values are
        /// session.regular, session.extended.
        /// </summary>
        public virtual string syminfo__session => throw new NotImplementedException();
        /// <summary>
        /// Symbol name without exchange prefix, e.g. 'MSFT'
        /// </summary>
        public virtual string syminfo__ticker => throw new NotImplementedException();
        /// <summary>
        /// Symbol name with exchange prefix, e.g. 'BATS:MSFT', 'NASDAQ:MSFT'
        /// </summary>
        public virtual string syminfo__tickerid => throw new NotImplementedException();
        /// <summary>
        /// Timezone of the exchange of the chart main series. Possible values see
        /// in timestamp.
        /// </summary>
        public virtual string syminfo__timezone => throw new NotImplementedException();
        /// <summary>
        /// Type of the current symbol. Possible values are stock, futures, index,
        /// forex, crypto, fund.
        /// </summary>
        public virtual string syminfo__type => throw new NotImplementedException();
        /// <summary>
        /// Label text alignment for label.new and label.set_textalign functions.
        /// </summary>
        public virtual string text__align_center => throw new NotImplementedException();
        /// <summary>
        /// Label text alignment for label.new and label.set_textalign functions.
        /// </summary>
        public virtual string text__align_left => throw new NotImplementedException();
        /// <summary>
        /// Label text alignment for label.new and label.set_textalign functions.
        /// </summary>
        public virtual string text__align_right => throw new NotImplementedException();
        /// <summary>
        /// Current bar time in UNIX format. It is the number of milliseconds that
        /// have elapsed since 00:00:00 UTC, 1 January 1970.
        /// </summary>
        public virtual PineSeries<long> time => throw new NotImplementedException();
        /// <summary>
        /// Current bar close time in UNIX format. It is the number of
        /// milliseconds that have elapsed since 00:00:00 UTC, 1 January 1970. On
        /// price-based charts this variable value is na.
        /// </summary>
        public virtual PineSeries<long> time_close => throw new NotImplementedException();
        /// <summary>
        /// Returns true if current resolution is a daily resolution, false
        /// otherwise.
        /// </summary>
        public virtual bool timeframe__isdaily => throw new NotImplementedException();
        /// <summary>
        /// Returns true if current resolution is a daily or weekly or monthly
        /// resolution, false otherwise.
        /// </summary>
        public virtual bool timeframe__isdwm => throw new NotImplementedException();
        /// <summary>
        /// Returns true if current resolution is an intraday (minutes or seconds)
        /// resolution, false otherwise.
        /// </summary>
        public virtual bool timeframe__isintraday => throw new NotImplementedException();
        /// <summary>
        /// Returns true if current resolution is a minutes resolution, false
        /// otherwise.
        /// </summary>
        public virtual bool timeframe__isminutes => throw new NotImplementedException();
        /// <summary>
        /// Returns true if current resolution is a monthly resolution, false
        /// otherwise.
        /// </summary>
        public virtual bool timeframe__ismonthly => throw new NotImplementedException();
        /// <summary>
        /// Returns true if current resolution is a seconds resolution, false
        /// otherwise.
        /// </summary>
        public virtual bool timeframe__isseconds => throw new NotImplementedException();
        /// <summary>
        /// Returns true if current resolution is a weekly resolution, false
        /// otherwise.
        /// </summary>
        public virtual bool timeframe__isweekly => throw new NotImplementedException();
        /// <summary>
        /// Multiplier of resolution, e.g. '60' - 60, 'D' - 1, '5D' - 5, '12M' -
        /// 12
        /// </summary>
        public virtual long timeframe__multiplier => throw new NotImplementedException();
        /// <summary>
        /// Resolution, e.g. '60' - 60 minutes, 'D' - daily, 'W' - weekly, 'M' -
        /// monthly, '5D' - 5 days, '12M' - one year, '3M' - one quarter
        /// </summary>
        public virtual string timeframe__period => throw new NotImplementedException();
        /// <summary>
        /// Current time in UNIX format. It is the number of milliseconds that
        /// have elapsed since 00:00:00 UTC, 1 January 1970.
        /// </summary>
        public virtual PineSeries<long> timenow => throw new NotImplementedException();
        /// <summary>
        /// True range. Same as tr(false). It is max(high - low, abs(high -
        /// close[1]), abs(low - close[1]))
        /// </summary>
        public virtual PineSeries<float> tr => throw new NotImplementedException();
        /// <summary>
        /// Current bar volume.
        /// </summary>
        public virtual PineSeries<float> volume => throw new NotImplementedException();
        /// <summary>
        /// Volume-weighted average price. It uses hlc3 as a source series.
        /// </summary>
        public virtual PineSeries<float> vwap => throw new NotImplementedException();
        /// <summary>
        /// Williams Accumulation/Distribution
        /// </summary>
        public virtual PineSeries<float> wad => throw new NotImplementedException();
        /// <summary>
        /// Week number of current bar time in exchange timezone.
        /// </summary>
        public virtual PineSeries<long> weekofyear => throw new NotImplementedException();
        /// <summary>
        /// Williams Variable Accumulation/Distribution
        /// </summary>
        public virtual PineSeries<float> wvad => throw new NotImplementedException();
        /// <summary>
        /// A named constant that specifies the algorithm of interpretation of
        /// x-value in functions line.new and label.new. If xloc = xloc.bar_index,
        /// value of x is a bar index
        /// </summary>
        public virtual string xloc__bar_index => throw new NotImplementedException();
        /// <summary>
        /// A named constant that specifies the algorithm of interpretation of
        /// x-value in functions line.new and label.new. If xloc = xloc.bar_time,
        /// value of x is a bar UNIX time
        /// </summary>
        public virtual string xloc__bar_time => throw new NotImplementedException();
        /// <summary>
        /// Current bar year in exchange timezone.
        /// </summary>
        public virtual PineSeries<long> year => throw new NotImplementedException();
        /// <summary>
        /// A named constant that specifies the algorithm of interpretation of
        /// y-value in function label.new
        /// </summary>
        public virtual string yloc__abovebar => throw new NotImplementedException();
        /// <summary>
        /// A named constant that specifies the algorithm of interpretation of
        /// y-value in function label.new
        /// </summary>
        public virtual string yloc__belowbar => throw new NotImplementedException();
        /// <summary>
        /// A named constant that specifies the algorithm of interpretation of
        /// y-value in function label.new
        /// </summary>
        public virtual string yloc__price => throw new NotImplementedException();
    }
}
