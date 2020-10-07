using System;

namespace Razensoft.Trade.Pine
{
    public abstract partial class BuiltinFunctionProvider
    {
        /// <summary>
        /// Absolute value of x is x if x &gt;= 0, or -x otherwise.
        /// </summary>
        public virtual long abs(object x)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The acos function returns the arccosine (in radians) of number such
        /// that cos(acos(y)) = y for y in range [-1, 1].
        /// </summary>
        public virtual float acos(object x)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Creates alert condition, that is available in Create Alert dialog.
        /// Please note, that alertcondition does NOT create an alert, it just
        /// gives you more options in Create Alert dialog. Also, alertcondition
        /// effect is invisible on chart.
        /// </summary>
        public virtual void alertcondition(object condition, object title, object message)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Arnaud Legoux Moving Average. It uses Gaussian distribution as weights
        /// for moving average.
        /// </summary>
        public virtual PineSeries<float> alma(
            object series, object length, object offset, object sigma)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The function returns the mean of an array's elements.
        /// </summary>
        public virtual PineSeries<float> array__avg(object id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The function removes all elements from an array.
        /// </summary>
        public virtual void array__clear(object id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The function is used to merge two arrays. It pushes all elements from
        /// the second array to the first array, and returns the first array.
        /// </summary>
        public virtual object array__concat(object id1, object id2)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The function creates a copy of an existing array.
        /// </summary>
        public virtual object array__copy(object id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The function returns the covariance of two arrays.
        /// </summary>
        public virtual PineSeries<float> array__covariance(object id1, object id2)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The function sets elements of an array to a single value. If no index
        /// is specified, all elements are set. If only a start index (default 0)
        /// is supplied, the elements starting at that index are set. If both
        /// index parameters are used, the elements from the starting index up to
        /// but not including the end index (default na) are set.
        /// </summary>
        public virtual void array__fill(
            object id, object value, object index_from, object index_to)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The function returns the value of the element at the specified index.
        /// </summary>
        public virtual PineSeries<float> array__get(object id, object index)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The function returns true if the value was found in an array, false
        /// otherwise.
        /// </summary>
        public virtual PineSeries<bool> array__includes(object id, object value)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The function returns the index of the first occurrence of the value,
        /// or -1 if the value is not found.
        /// </summary>
        public virtual PineSeries<long> array__indexof(object id, object value)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The function changes the contents of an array by adding new elements
        /// in place.
        /// </summary>
        public virtual void array__insert(object id, object index, object value)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The function returns the index of the last occurrence of the value, or
        /// -1 if the value is not found.
        /// </summary>
        public virtual PineSeries<long> array__lastindexof(object id, object value)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The function returns the largest value from a given array.
        /// </summary>
        public virtual PineSeries<float> array__max(object id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The function returns the median of an array's elements.
        /// </summary>
        public virtual PineSeries<float> array__median(object id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The function returns the lowest value from a given array.
        /// </summary>
        public virtual PineSeries<float> array__min(object id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The function returns the mode of an array's elements. If there are
        /// several values with the same frequency, it returns the smallest value.
        /// </summary>
        public virtual PineSeries<float> array__mode(object id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The function creates a new array object of bool type elements.
        /// </summary>
        public virtual object array__new_bool(object size, object initial_value)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The function creates a new array object of color type elements.
        /// </summary>
        public virtual object array__new_color(object size, object initial_value)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The function creates a new array object of float type elements.
        /// </summary>
        public virtual object array__new_float(object size, object initial_value)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The function creates a new array object of int type elements.
        /// </summary>
        public virtual object array__new_int(object size, object initial_value)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The function removes the last element from an array and returns its
        /// value.
        /// </summary>
        public virtual PineSeries<float> array__pop(object id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The function appends a value to an array.
        /// </summary>
        public virtual void array__push(object id, object value)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The function changes the contents of an array by removing the element
        /// with the specified index.
        /// </summary>
        public virtual PineSeries<float> array__remove(object id, object index)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The function reverses an array. The first array element becomes the
        /// last, and the last array element becomes the first.
        /// </summary>
        public virtual void array__reverse(object id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The function sets the value of the element at the specified index.
        /// </summary>
        public virtual void array__set(object id, object index, object value)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The function removes an array's first element and returns its value.
        /// </summary>
        public virtual PineSeries<float> array__shift(object id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The function returns the number of elements in an array.
        /// </summary>
        public virtual PineSeries<long> array__size(object id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The function creates a slice from an existing array. If an object from
        /// the slice changes, the changes are applied to both the new and the
        /// original arrays.
        /// </summary>
        public virtual object array__slice(object id, object index_from, object index_to)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The function sorts the elements of an array.
        /// </summary>
        public virtual void array__sort(object id, object order)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The function returns the array of standardized elements.
        /// </summary>
        public virtual object array__standardize(object id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The function returns the standard deviation of an array's elements.
        /// </summary>
        public virtual PineSeries<float> array__stdev(object id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The function returns the sum of an array's elements.
        /// </summary>
        public virtual PineSeries<float> array__sum(object id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The function inserts the value at the beginning of the array.
        /// </summary>
        public virtual void array__unshift(object id, object value)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The function returns the variance of an array's elements.
        /// </summary>
        public virtual PineSeries<float> array__variance(object id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The asin function returns the arcsine (in radians) of number such that
        /// sin(asin(y)) = y for y in range [-1, 1].
        /// </summary>
        public virtual float asin(object x)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The atan function returns the arctangent (in radians) of number such
        /// that tan(atan(y)) = y for any y.
        /// </summary>
        public virtual float atan(object x)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Function atr (average true range) returns the RMA of true range. True
        /// range is max(high - low, abs(high - close[1]), abs(low - close[1]))
        /// </summary>
        public virtual PineSeries<float> atr(object length)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Calculates average of all given series (elementwise).
        /// </summary>
        public virtual PineSeries<float> avg(object x1, object x2, object x10)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Set color of bars.
        /// </summary>
        public virtual void barcolor(
            object color, object offset, object editable, object show_last,
            object title)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Counts the number of bars since the last time the condition was true.
        /// </summary>
        public virtual PineSeries<long> barssince(object condition)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Bollinger Bands. A Bollinger Band is a technical analysis tool defined
        /// by a set of lines plotted two standard deviations (positively and
        /// negatively) away from a simple moving average (SMA) of the security's
        /// price, but can be adjusted to user preferences.
        /// </summary>
        public virtual object bb(object series, object length, object mult)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Bollinger Bands Width. The Bollinger Band Width is the difference
        /// between the upper and the lower Bollinger Bands divided by the middle
        /// band.
        /// </summary>
        public virtual PineSeries<float> bbw(object series, object length, object mult)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Fill background of bars with specified color.
        /// </summary>
        public virtual void bgcolor(
            object color, object transp, object offset, object editable,
            object show_last, object title)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Casts na to bool
        /// </summary>
        public virtual bool @bool(object x)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The CCI (commodity channel index) is calculated as the difference
        /// between the typical price of a commodity and its simple moving
        /// average, divided by the mean absolute deviation of the typical price.
        /// The index is scaled by an inverse factor of 0.015 to provide more
        /// readable numbers
        /// </summary>
        public virtual PineSeries<float> cci(object source, object length)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The ceil function returns the smallest (closest to negative infinity)
        /// integer that is greater than or equal to the argument.
        /// </summary>
        public virtual long ceil(object x)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Difference between current value and previous, x - x[y].
        /// </summary>
        public virtual PineSeries<float> change(object source, object length)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Difference between current value and previous, x - x[y].
        /// </summary>
        public virtual PineSeries<float> change(object source)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Chande Momentum Oscillator. Calculates the difference between the sum
        /// of recent gains and the sum of recent losses and then divides the
        /// result by the sum of all price movement over the same period.
        /// </summary>
        public virtual PineSeries<float> cmo(object series, object length)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The cog (center of gravity) is an indicator based on statistics and
        /// the Fibonacci golden ratio.
        /// </summary>
        public virtual PineSeries<float> cog(object source, object length)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Casts na to color
        /// </summary>
        public virtual PineColor color(object x)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Function color applies the specified transparency to the given color.
        /// </summary>
        public virtual PineColor color__new(object color, object transp)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Correlation coefficient. Describes the degree to which two series tend
        /// to deviate from their sma values.
        /// </summary>
        public virtual PineSeries<float> correlation(object source_a, object source_b, object length)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The cos function returns the trigonometric cosine of an angle.
        /// </summary>
        public virtual float cos(object x)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// cross(x, y) → series[bool]
        /// </summary>
        public virtual PineSeries<bool> cross(object x, object y)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The `x`-series is defined as having crossed over `y`-series if the
        /// value of `x` is greater than the value of `y` and the value of `x` was
        /// less than the value of `y` on the bar immediately preceding the
        /// current bar.
        /// </summary>
        public virtual PineSeries<bool> crossover(object x, object y)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The `x`-series is defined as having crossed under `y`-series if the
        /// value of `x` is less than the value of `y` and the value of `x` was
        /// greater than the value of `y` on the bar immediately preceding the
        /// current bar.
        /// </summary>
        public virtual PineSeries<bool> crossunder(object x, object y)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Cumulative (total) sum of x. In other words it's a sum of all elements
        /// of x.
        /// </summary>
        public virtual PineSeries<float> cum(object x)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// dayofmonth(time) → series[integer]
        /// </summary>
        public virtual PineSeries<long> dayofmonth(object time)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// dayofmonth(time) → series[integer]
        /// </summary>
        public virtual PineSeries<long> dayofmonth(object time, object timezone)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// dayofweek(time) → series[integer]
        /// </summary>
        public virtual PineSeries<long> dayofweek(object time)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// dayofweek(time) → series[integer]
        /// </summary>
        public virtual PineSeries<long> dayofweek(object time, object timezone)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Measure of difference between the series and it's sma
        /// </summary>
        public virtual PineSeries<float> dev(object source, object length)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The dmi function returns the directional movement index.
        /// </summary>
        public virtual object dmi(object diLength, object adxSmoothing)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The ema function returns the exponentially weighted moving average. In
        /// ema weighting factors decrease exponentially. It calculates by using a
        /// formula: EMA = alpha * x + (1 - alpha) * EMA[1], where alpha = 2 / (y
        /// + 1)
        /// </summary>
        public virtual PineSeries<float> ema(object source, object length)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The exp function of x is e^x, where x is the argument and e is Euler's
        /// number.
        /// </summary>
        public virtual float exp(object x)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Test if the x series is now falling for y bars long.
        /// </summary>
        public virtual PineSeries<bool> falling(object source, object length)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Fills background between two plots or hlines with a given color.
        /// </summary>
        public virtual void fill(
            object hline1, object hline2, object color, object transp, object title,
            object editable)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Fills background between two plots or hlines with a given color.
        /// </summary>
        public virtual void fill(
            object plot1, object plot2, object color, object transp, object title,
            object editable, object show_last)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Requests financial series for symbol.
        /// </summary>
        public virtual PineSeries<float> financial(
            object symbol, object financial_id, object period, object gaps)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// For a given series replaces NaN values with previous nearest non-NaN
        /// value.
        /// </summary>
        public virtual PineSeries<float> fixnan(object x)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Casts na to float
        /// </summary>
        public virtual float @float(object x)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// floor(x) → integer
        /// </summary>
        public virtual long floor(object x)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Creates a ticker identifier for requesting Heikin Ashi bar values.
        /// </summary>
        public virtual string heikinashi(object symbol)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Highest value for a given number of bars back.
        /// </summary>
        public virtual PineSeries<float> highest(object source, object length)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Highest value for a given number of bars back.
        /// </summary>
        public virtual PineSeries<float> highest(object length)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Highest value offset for a given number of bars back.
        /// </summary>
        public virtual PineSeries<long> highestbars(object source, object length)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Highest value offset for a given number of bars back.
        /// </summary>
        public virtual PineSeries<long> highestbars(object length)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Renders a horizontal line at a given fixed price level.
        /// </summary>
        public virtual object hline(
            object price, object title, object color, object linestyle, object linewidth,
            object editable)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The hma function returns the Hull Moving Average.
        /// </summary>
        public virtual PineSeries<float> hma(object source, object length)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// hour(time) → series[integer]
        /// </summary>
        public virtual PineSeries<long> hour(object time)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// hour(time) → series[integer]
        /// </summary>
        public virtual PineSeries<long> hour(object time, object timezone)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// If ... then ... else ...
        /// </summary>
        public virtual bool iff(object condition, object then, object _else)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Casts na or truncates float value to int
        /// </summary>
        public virtual long @int(object x)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Creates a ticker identifier for requesting Kagi values.
        /// </summary>
        public virtual string kagi(object symbol, object reversal)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Keltner Channels. Keltner channel is a technical analysis indicator
        /// showing a central moving average line plus channel lines at a distance
        /// above and below.
        /// </summary>
        public virtual object kc(object series, object length, object mult)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Keltner Channels. Keltner channel is a technical analysis indicator
        /// showing a central moving average line plus channel lines at a distance
        /// above and below.
        /// </summary>
        public virtual object kc(
            object series, object length, object mult, object useTrueRange)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Keltner Channels Width. The Keltner Channels Width is the difference
        /// between the upper and the lower Keltner Channels divided by the middle
        /// channel.
        /// </summary>
        public virtual PineSeries<float> kcw(object series, object length, object mult)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Keltner Channels Width. The Keltner Channels Width is the difference
        /// between the upper and the lower Keltner Channels divided by the middle
        /// channel.
        /// </summary>
        public virtual PineSeries<float> kcw(
            object series, object length, object mult, object useTrueRange)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Casts na to label
        /// </summary>
        public virtual object label(object x)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Deletes the specified label object. If it has already been deleted,
        /// does nothing.
        /// </summary>
        public virtual void label__delete(object id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Returns the text of this label object
        /// </summary>
        public virtual PineSeries<string> label__get_text(object id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Returns UNIX time or bar index (depending on the last xloc value set)
        /// of this label's position
        /// </summary>
        public virtual PineSeries<long> label__get_x(object id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Returns price of this label's position
        /// </summary>
        public virtual PineSeries<float> label__get_y(object id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Creates new label object
        /// </summary>
        public virtual object label__new(
            object x, object y, object text, object xloc, object yloc, object color,
            object style, object textcolor, object size, object textalign,
            object tooltip)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Sets label border and arrow color
        /// </summary>
        public virtual void label__set_color(object id, object color)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Sets arrow and text size of the specified label object.
        /// </summary>
        public virtual void label__set_size(object id, object size)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Sets label style
        /// </summary>
        public virtual void label__set_style(object id, object style)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Sets label text
        /// </summary>
        public virtual void label__set_text(object id, object text)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Sets the alignment for the label text.
        /// </summary>
        public virtual void label__set_textalign(object id, object textalign)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Sets color of the label text
        /// </summary>
        public virtual void label__set_textcolor(object id, object textcolor)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Sets the tooltip text.
        /// </summary>
        public virtual void label__set_tooltip(object id, object tooltip)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Sets bar index or bar time (depending on the xloc) of the label
        /// position
        /// </summary>
        public virtual void label__set_x(object id, object x)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Sets x-location and new bar index/time value
        /// </summary>
        public virtual void label__set_xloc(object id, object x, object xloc)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Sets bar index/time and price of the label position
        /// </summary>
        public virtual void label__set_xy(object id, object x, object y)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Sets price of the label position
        /// </summary>
        public virtual void label__set_y(object id, object y)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Sets new y-location calculation algorithm
        /// </summary>
        public virtual void label__set_yloc(object id, object yloc)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Casts na to line
        /// </summary>
        public virtual object line(object x)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Deletes the specified line object. If it has already been deleted,
        /// does nothing.
        /// </summary>
        public virtual void line__delete(object id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Returns the price level of a line at a given bar index.
        /// </summary>
        public virtual PineSeries<float> line__get_price(object id, object x)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Returns UNIX time or bar index (depending on the last xloc value set)
        /// of the first point of the line
        /// </summary>
        public virtual PineSeries<long> line__get_x1(object id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Returns UNIX time or bar index (depending on the last xloc value set)
        /// of the second point of the line
        /// </summary>
        public virtual PineSeries<long> line__get_x2(object id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Returns price of the first point of the line
        /// </summary>
        public virtual PineSeries<float> line__get_y1(object id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Returns price of the second point of the line
        /// </summary>
        public virtual PineSeries<float> line__get_y2(object id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Creates new line object
        /// </summary>
        public virtual object line__new(
            object x1, object y1, object x2, object y2, object xloc, object extend,
            object color, object style, object width)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Sets the line color
        /// </summary>
        public virtual void line__set_color(object id, object color)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Sets extending type of this line object. If extend=extend.none, draws
        /// segment starting at point (x1, y1) and ending at point (x2, y2). If
        /// extend is equal to extend.right or extend.left, draws a ray starting
        /// at point (x1, y1) or (x2, y2), respectively. If extend=extend.both,
        /// draws a straight line that goes through these points.
        /// </summary>
        public virtual void line__set_extend(object id, object extend)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Sets the line style
        /// </summary>
        public virtual void line__set_style(object id, object style)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Sets the line width
        /// </summary>
        public virtual void line__set_width(object id, object width)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Sets bar index or bar time (depending on the xloc) of the first point
        /// </summary>
        public virtual void line__set_x1(object id, object x)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Sets bar index or bar time (depending on the xloc) of the second point
        /// </summary>
        public virtual void line__set_x2(object id, object x)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Sets x-location and new bar index/time values
        /// </summary>
        public virtual void line__set_xloc(
            object id, object x1, object x2, object xloc)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Sets bar index/time and price of the first point
        /// </summary>
        public virtual void line__set_xy1(object id, object x, object y)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Sets bar index/time and price of the second point
        /// </summary>
        public virtual void line__set_xy2(object id, object x, object y)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Sets price of the first point
        /// </summary>
        public virtual void line__set_y1(object id, object y)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Sets price of the second point
        /// </summary>
        public virtual void line__set_y2(object id, object y)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Creates a ticker identifier for requesting Line Break values.
        /// </summary>
        public virtual string linebreak(object symbol, object number_of_lines)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Linear regression curve. A line that best fits the prices specified
        /// over a user-defined time period. It is calculated using the least
        /// squares method. The result of this function is calculated using the
        /// formula: linreg = intercept + slope * (length - 1 - offset), where
        /// length is the y argument, offset is the z argument, intercept and
        /// slope are the values calculated with the least squares method on
        /// source series (x argument).
        /// </summary>
        public virtual PineSeries<float> linreg(object source, object length, object offset)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Natural logarithm of any x &gt; 0 is the unique `y` such that e^y = x
        /// </summary>
        public virtual float log(object x)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Base 10 logarithm of any x &gt; 0 is the unique `y` such that 10^y = x
        /// </summary>
        public virtual float log10(object x)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Lowest value for a given number of bars back.
        /// </summary>
        public virtual PineSeries<float> lowest(object source, object length)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Lowest value for a given number of bars back.
        /// </summary>
        public virtual PineSeries<float> lowest(object length)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Lowest value offset for a given number of bars back.
        /// </summary>
        public virtual PineSeries<long> lowestbars(object source, object length)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Lowest value offset for a given number of bars back.
        /// </summary>
        public virtual PineSeries<long> lowestbars(object length)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// MACD (moving average convergence/divergence). It is supposed to reveal
        /// changes in the strength, direction, momentum, and duration of a trend
        /// in a stock's price.
        /// </summary>
        public virtual object macd(
            object source, object fastlen, object slowlen, object siglen)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Function sets the maximum number of bars that is available for
        /// historical reference of a given built-in or user variable. When
        /// operator '[]' is applied to a variable - it is a reference to a
        /// historical value of that variable.
        /// </summary>
        public virtual void max_bars_back(object var, object num)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Money Flow Index. The Money Flow Index (MFI) is a technical oscillator
        /// that uses price and volume for identifying overbought or oversold
        /// conditions in an asset.
        /// </summary>
        public virtual PineSeries<float> mfi(object series, object length)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Returns the smallest of multiple values
        /// </summary>
        public virtual long min(object x1, object x2, object x10)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// minute(time) → series[integer]
        /// </summary>
        public virtual PineSeries<long> minute(object time)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// minute(time) → series[integer]
        /// </summary>
        public virtual PineSeries<long> minute(object time, object timezone)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Momentum of x price and x price y bars ago. This is simply a
        /// difference x - x[y].
        /// </summary>
        public virtual PineSeries<float> mom(object source, object length)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// month(time) → series[integer]
        /// </summary>
        public virtual PineSeries<long> month(object time)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// month(time) → series[integer]
        /// </summary>
        public virtual PineSeries<long> month(object time, object timezone)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Test value if it's a NaN.
        /// </summary>
        public virtual bool na(object x)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Shifts series x on the y bars to the right.
        /// </summary>
        public virtual PineSeries<bool> offset(object source, object offset)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Calculates percentile using method of linear interpolation between the
        /// two nearest ranks.
        /// </summary>
        public virtual PineSeries<float> percentile_linear_interpolation(object source, object length, object percentage)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Calculates percentile using method of Nearest Rank.
        /// </summary>
        public virtual PineSeries<float> percentile_nearest_rank(object source, object length, object percentage)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Percent rank is the percents of how many previous values was less than
        /// or equal to the current value of given series.
        /// </summary>
        public virtual PineSeries<float> percentrank(object source, object length)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// This function returns price of the pivot high point. It returns 'NaN',
        /// if there was no pivot high point.
        /// </summary>
        public virtual PineSeries<float> pivothigh(object source, object leftbars, object rightbars)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// This function returns price of the pivot high point. It returns 'NaN',
        /// if there was no pivot high point.
        /// </summary>
        public virtual PineSeries<float> pivothigh(object leftbars, object rightbars)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// This function returns price of the pivot low point. It returns 'NaN',
        /// if there was no pivot low point.
        /// </summary>
        public virtual PineSeries<float> pivotlow(object source, object leftbars, object rightbars)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// This function returns price of the pivot low point. It returns 'NaN',
        /// if there was no pivot low point.
        /// </summary>
        public virtual PineSeries<float> pivotlow(object leftbars, object rightbars)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Plots a series of data on the chart.
        /// </summary>
        public virtual object plot(
            object series, object title, object color, object linewidth,
            object style, object trackprice, object transp, object histbase,
            object offset, object join, object editable, object show_last,
            object display)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Plots up and down arrows on the chart. Up arrow is drawn at every
        /// indicator positive value, down arrow is drawn at every negative value.
        /// If indicator returns na then no arrow is drawn. Arrows has different
        /// height, the more absolute indicator value the longer arrow is drawn.
        /// </summary>
        public virtual void plotarrow(
            object series, object title, object colorup, object colordown,
            object transp, object offset, object minheight, object maxheight,
            object editable, object show_last, object display)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Plots ohlc bars on the chart.
        /// </summary>
        public virtual void plotbar(
            object open, object high, object low, object close, object title,
            object color, object editable, object show_last, object display)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Plots candles on the chart.
        /// </summary>
        public virtual void plotcandle(
            object open, object high, object low, object close, object title,
            object color, object wickcolor, object editable, object show_last,
            object bordercolor, object display)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Plots visual shapes using any given one Unicode character on the
        /// chart.
        /// </summary>
        public virtual void plotchar(
            object series, object title, object @char, object location, object color,
            object transp, object offset, object text, object textcolor,
            object editable, object size, object show_last, object display)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Plots visual shapes on the chart.
        /// </summary>
        public virtual void plotshape(
            object series, object title, object style, object location, object color,
            object transp, object offset, object text, object textcolor,
            object editable, object size, object show_last, object display)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Creates a ticker identifier for requesting Point &amp; Figure values.
        /// </summary>
        public virtual string pointfigure(
            object symbol, object source, object style, object param, object reversal)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Mathematical power function.
        /// </summary>
        public virtual float pow(object @base, object exponent)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Requests Quandl data for a symbol.
        /// </summary>
        public virtual PineSeries<float> quandl(object ticker, object gaps, object index)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Creates a ticker identifier for requesting Renko values.
        /// </summary>
        public virtual string renko(object symbol, object style, object param)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Test if the x series is now rising for y bars long.
        /// </summary>
        public virtual PineSeries<bool> rising(object source, object length)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Moving average used in RSI. It is the exponentially weighted moving
        /// average with alpha = 1 / length.
        /// </summary>
        public virtual PineSeries<float> rma(object source, object length)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Function roc (rate of change) showing the difference between current
        /// value of x and the value of x that was y days ago.
        /// </summary>
        public virtual PineSeries<float> roc(object source, object length)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The round function returns the value of the argument rounded to the
        /// nearest integer, with ties rounding up.
        /// </summary>
        public virtual long round(object x)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Relative strength index. It is calculated based on rma's of upward and
        /// downward change of x.
        /// </summary>
        public virtual PineSeries<float> rsi(object x, object y)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Parabolic SAR (parabolic stop and reverse) is a method devised by J.
        /// Welles Wilder, Jr., to find potential reversals in the market price
        /// direction of traded goods.
        /// </summary>
        public virtual PineSeries<float> sar(object start, object inc, object max)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// second(time) → series[integer]
        /// </summary>
        public virtual PineSeries<long> second(object time)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// second(time) → series[integer]
        /// </summary>
        public virtual PineSeries<long> second(object time, object timezone)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Request another symbol/resolution
        /// </summary>
        public virtual PineSeries<float> security(
            object symbol, object resolution, object expression, object gaps,
            object lookahead)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Sign (signum) of x is zero if the x is zero, 1.0 if the x is greater
        /// than zero, -1.0 if the x is less than zero.
        /// </summary>
        public virtual float sign(object x)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The sin function returns the trigonometric sine of an angle.
        /// </summary>
        public virtual float sin(object x)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The sma function returns the moving average, that is the sum of last y
        /// values of x, divided by y.
        /// </summary>
        public virtual PineSeries<float> sma(object source, object length)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Square root of any x &gt;= 0 is the unique y &gt;= 0 such that y^2 = x
        /// </summary>
        public virtual float sqrt(object x)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// stdev(source, length) → series[float]
        /// </summary>
        public virtual PineSeries<float> stdev(object source, object length)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Stochastic. It is calculated by a formula: 100 * (close - lowest(low,
        /// length)) / (highest(high, length) - lowest(low, length))
        /// </summary>
        public virtual PineSeries<float> stoch(
            object source, object high, object low, object length)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Replaces each occurrence of the target string in the source string
        /// with the replacement string.
        /// </summary>
        public virtual string str__replace_all(object source, object target, object replacement)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The function sets a number of strategy properties.
        /// </summary>
        public virtual void strategy(
            object title, object shorttitle, object overlay, object format,
            object precision, object scale, object pyramiding, object calc_on_order_fills,
            object calc_on_every_tick, object max_bars_back, object backtest_fill_limits_assumption,
            object default_qty_type, object default_qty_value, object initial_capital,
            object currency, object slippage, object commission_type, object commission_value,
            object process_orders_on_close, object close_entries_rule)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// It is a command to cancel/deactivate pending orders by referencing
        /// their names, which were generated by the functions: strategy.order,
        /// strategy.entry and strategy.exit.
        /// </summary>
        public virtual void strategy__cancel(object id, object when)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// It is a command to cancel/deactivate all pending orders, which were
        /// generated by the functions: strategy.order, strategy.entry and
        /// strategy.exit.
        /// </summary>
        public virtual void strategy__cancel_all(object when)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// It is a command to exit from the entry with the specified ID. If there
        /// were multiple entry orders with the same ID, all of them are exited at
        /// once. If there are no open entries with the specified ID by the moment
        /// the command is triggered, the command will not come into effect. The
        /// command uses market order. Every entry is closed by a separate market
        /// order.
        /// </summary>
        public virtual void strategy__close(
            object id, object when, object comment, object qty, object qty_percent,
            object alert_message)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// It is a command to exit from current market position making it flat.
        /// If there is no open market position by the moment the command is
        /// triggered, the command will not come into effect.
        /// </summary>
        public virtual void strategy__close_all(object when, object comment, object alert_message)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// It is a command to enter market position. If an order with the same ID
        /// is already pending, it is possible to modify the order. If there is no
        /// order with the specified ID, a new order is placed. To deactivate an
        /// entry order, the command strategy.cancel or strategy.cancel_all should
        /// be used. In comparison to the function strategy.order, the function
        /// strategy.entry is affected by pyramiding and it can reverse market
        /// position correctly. If both 'limit' and 'stop' parameters are 'NaN',
        /// the order type is market order.
        /// </summary>
        public virtual void strategy__entry(
            object id, object @long, object qty, object limit, object stop,
            object oca_name, object oca_type, object comment, object when,
            object alert_message)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// It is a command to exit either a specific entry, or whole market
        /// position. If an order with the same ID is already pending, it is
        /// possible to modify the order. If an entry order was not filled, but an
        /// exit order is generated, the exit order will wait till entry order is
        /// filled and then the exit order is placed. To deactivate an exit order,
        /// the command strategy.cancel or strategy.cancel_all should be used. If
        /// the function strategy.exit is called once, it exits a position only
        /// once. If you want to exit multiple times, the command strategy.exit
        /// should be called multiple times. If you use a stop loss and a trailing
        /// stop, their order type is 'stop', so only one of them is placed (the
        /// one that is supposed to be filled first). If all the following
        /// parameters 'profit', 'limit', 'loss', 'stop', 'trail_points',
        /// 'trail_offset' are 'NaN', the command will fail. To use market order
        /// to exit, the command strategy.close or strategy.close_all should be
        /// used.
        /// </summary>
        public virtual void strategy__exit(
            object id, object from_entry, object qty, object qty_percent,
            object profit, object limit, object loss, object stop, object trail_price,
            object trail_points, object trail_offset, object oca_name, object comment,
            object when, object alert_message)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// It is a command to place order. If an order with the same ID is
        /// already pending, it is possible to modify the order. If there is no
        /// order with the specified ID, a new order is placed. To deactivate
        /// order, the command strategy.cancel or strategy.cancel_all should be
        /// used. In comparison to the function strategy.entry, the function
        /// strategy.order is not affected by pyramiding. If both 'limit' and
        /// 'stop' parameters are 'NaN', the order type is market order.
        /// </summary>
        public virtual void strategy__order(
            object id, object @long, object qty, object limit, object stop,
            object oca_name, object oca_type, object comment, object when,
            object alert_message)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The purpose of this rule is to forbid short entries, only long etries
        /// will be placed. The rule affects the following function: 'entry'.
        /// </summary>
        public virtual void strategy__risk__allow_entry_in(object value)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The purpose of this rule is to cancel all pending orders, close all
        /// open positions and stop placing orders after a specified number of
        /// consecutive days with losses. The rule affects the whole strategy.
        /// </summary>
        public virtual void strategy__risk__max_cons_loss_days(object count)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The purpose of this rule is to determine maximum drawdown. The rule
        /// affects the whole strategy. Once the maximum drawdown value is
        /// reached, all pending orders are cancelled, all open positions are
        /// closed and no new orders can be placed.
        /// </summary>
        public virtual void strategy__risk__max_drawdown(object value, object type)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The purpose of this rule is to determine maximum number of filled
        /// orders per 1 day (per 1 bar, if chart resolution is higher than 1
        /// day). The rule affects the whole strategy. Once the maximum number of
        /// filled orders is reached, all pending orders are cancelled, all open
        /// positions are closed and no new orders can be placed till the end of
        /// the current trading session.
        /// </summary>
        public virtual void strategy__risk__max_intraday_filled_orders(object count)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The purpose of this rule is to determine maximum loss per 1 day (per 1
        /// bar, if chart resolution is higher than 1 day). The rule affects the
        /// whole strategy. Once the maximum loss value is reached, all pending
        /// orders are cancelled, all open positions are closed and no new orders
        /// can be placed till the end of the current trading session.
        /// </summary>
        public virtual void strategy__risk__max_intraday_loss(object value, object type)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The purpose of this rule is to determine maximum size of a market
        /// position. The rule affects the following function: strategy.entry. The
        /// 'entry' quantity can be reduced (if needed) to such number of
        /// contracts/shares/lots/units, so the total position size doesn't exceed
        /// the value specified in 'strategy.risk.max_position_size'. If minimum
        /// possible quantity still violates the rule, the order will not be
        /// placed.
        /// </summary>
        public virtual void strategy__risk__max_position_size(object contracts)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Casts na to string
        /// </summary>
        public virtual string @string(object x)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The function sets a number of study properties.
        /// </summary>
        public virtual void study(
            object title, object shorttitle, object overlay, object format,
            object precision, object scale, object max_bars_back, object resolution)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The sum function returns the sliding sum of last y values of x.
        /// </summary>
        public virtual PineSeries<float> sum(object source, object length)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The Supertrend Indicator. The Supertrend is a trend following
        /// indicator.
        /// </summary>
        public virtual object supertrend(object factor, object atrPeriod)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Symmetrically weighted moving average with fixed length: 4. Weights:
        /// [1/6, 2/6, 2/6, 1/6].
        /// </summary>
        public virtual PineSeries<float> swma(object x)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The tan function returns the trigonometric tangent of an angle.
        /// </summary>
        public virtual float tan(object x)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Creates a ticker identifier for requesting additional data for the
        /// script.
        /// </summary>
        public virtual string tickerid(
            object prefix, object ticker, object session, object adjustment)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Function time returns UNIX time of current bar for the specified
        /// resolution and session or NaN if time point is out-of-session.
        /// </summary>
        public virtual PineSeries<long> time(object resolution, object session)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Function time returns UNIX time of current bar for the specified
        /// resolution and session or NaN if time point is out-of-session.
        /// </summary>
        public virtual PineSeries<long> time(object resolution)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Function timestamp returns UNIX time of specified date and time.
        /// </summary>
        public virtual long timestamp(
            object year, object month, object day, object hour, object minute,
            object second)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Function timestamp returns UNIX time of specified date and time.
        /// </summary>
        public virtual long timestamp(
            object timezone, object year, object month, object day, object hour,
            object minute, object second)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// tostring(x) → series[string]
        /// </summary>
        public virtual PineSeries<string> tostring(object x)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// tostring(x) → series[string]
        /// </summary>
        public virtual PineSeries<string> tostring(object x, object y)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// tr(handle_na) → series[float]
        /// </summary>
        public virtual PineSeries<float> tr(object handle_na)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// True strength index. It uses moving averages of the underlying
        /// momentum of a financial instrument.
        /// </summary>
        public virtual PineSeries<float> tsi(object source, object short_length, object long_length)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Source series value when the condition was true on the n-th most
        /// recent occurrence.
        /// </summary>
        public virtual PineSeries<float> valuewhen(object condition, object source, object occurrence)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Variance is the expectation of the squared deviation of a series from
        /// its mean (sma), and it informally measures how far a set of numbers
        /// are spread out from their mean.
        /// </summary>
        public virtual PineSeries<float> variance(object source, object length)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Volume weighted average price.
        /// </summary>
        public virtual PineSeries<float> vwap(object x)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The vwma function returns volume-weighted moving average of x for y
        /// bars back. It is the same as: sma(x * volume, y) / sma(volume, y)
        /// </summary>
        public virtual PineSeries<float> vwma(object source, object length)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// weekofyear(time) → series[integer]
        /// </summary>
        public virtual PineSeries<long> weekofyear(object time)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// weekofyear(time) → series[integer]
        /// </summary>
        public virtual PineSeries<long> weekofyear(object time, object timezone)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The wma function returns weighted moving average of x for y bars back.
        /// In wma weighting factors decrease in arithmetical progression.
        /// </summary>
        public virtual PineSeries<float> wma(object source, object length)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Williams %R. The oscillator shows the current closing price in
        /// relation to the high and low of the past 'length' bars.
        /// </summary>
        public virtual PineSeries<float> wpr(object length)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// year(time) → series[integer]
        /// </summary>
        public virtual PineSeries<long> year(object time)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// year(time) → series[integer]
        /// </summary>
        public virtual PineSeries<long> year(object time, object timezone)
        {
            throw new NotImplementedException();
        }
    }
}
