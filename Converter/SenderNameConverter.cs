using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfMailClient.Converter
{
    class SenderNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var addres = (MimeKit.InternetAddressList)value;// = (string)value.
           var res =  addres.First().Name;
            //var start = addres.IndexOf("\"") + 1;//add one to not include quote
            //var end = addres.LastIndexOf("\"") - start;
            //var result = addres.Substring(start, end);
            return res;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
