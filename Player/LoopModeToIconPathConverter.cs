﻿using System;
using System.Globalization;
using System.Windows.Data;
using Music.Player.Enum;

namespace Music.Player
{
    class LoopModeToIconPathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is LoopModes loopModes)
            {
                return loopModes switch
                {
                    LoopModes.InOrder =>
                        "M16,392A16,16,0,0,1,0,376V336a16,16,0,0,1,16-16H299a16,16,0,0,1,16,16v40a16,16,0,0,1-16,16Zm328.09-8.847V276.159c0-8.074,5.3-11.2,11.794-6.962l88.957,55.124c-.011,0,3.159,2.234,3.159,5.341S444.83,335,444.83,335l-41.4,25.643-47.56,29.46A10.149,10.149,0,0,1,350.426,392C346.667,392,344.091,388.77,344.091,383.153ZM16,232A16,16,0,0,1,0,216V176a16,16,0,0,1,16-16H432a16,16,0,0,1,16,16v40a16,16,0,0,1-16,16ZM16,72A16,16,0,0,1,0,56V16A16,16,0,0,1,16,0H432a16,16,0,0,1,16,16V56a16,16,0,0,1-16,16Z",

                    LoopModes.LoopList =>
                        "M228.936 833.464c13.33 13.33 13.33 34.942 0 48.271s-34.942 13.33-48.271 0l-136.534-136.533c-13.33-13.33-13.33-34.942 0-48.271l136.534-136.533c13.33-13.33 34.942-13.33 48.271 0s13.33 34.942 0 48.271l-78.264 78.264h497.861c131.959 0 238.933-106.974 238.933-238.933 0-18.851 15.285-34.133 34.133-34.133s34.133 15.282 34.133 34.133c0 169.662-137.537 307.2-307.2 307.2h-497.861l78.264 78.264zM136.533 448c0 18.851-15.282 34.133-34.133 34.133s-34.133-15.282-34.133-34.133c0-169.662 137.538-307.2 307.2-307.2h497.862l-78.268-78.261c-13.326-13.332-13.326-34.946 0-48.278 13.332-13.326 34.946-13.326 48.278 0l136.533 136.533c13.326 13.332 13.326 34.946 0 48.278l-136.533 136.53c-13.332 13.33-34.946 13.33-48.278 0-13.326-13.33-13.326-34.942 0-48.271l78.268-78.264h-497.862c-131.959 0-238.933 106.974-238.933 238.933z",

                    LoopModes.Random =>
                        "M843.339 881.736c-13.332 13.33-34.946 13.33-48.278 0-13.326-13.33-13.326-34.942 0-48.271l78.268-78.264h-54.129c-88.494 0-156.255-39.883-213.505-94.844-45.864-44.029-87.312-100.183-128.196-155.572-8.993-12.184-17.959-24.332-26.939-36.304-101.803-135.738-212.284-259.413-416.427-259.413-18.851 0-34.133-15.285-34.133-34.133s15.282-34.133 34.133-34.133c239.591 0 368.043 149.391 471.040 286.72 9.808 13.076 19.333 25.967 28.669 38.602l0.007 0.009c40.733 55.123 77.867 105.374 119.123 144.979 49.417 47.44 101.122 75.823 166.228 75.823h54.129l-78.268-78.264c-13.326-13.33-13.326-34.942 0-48.271 13.332-13.33 34.946-13.33 48.278 0l136.533 136.533c13.326 13.33 13.326 34.942 0 48.271l-136.533 136.533zM34.133 755.2c194.75 0 316.069-98.705 409.974-209.405l-8.826-11.96c-8.731-11.84-17.29-23.445-25.682-34.634-2.46-3.28-4.917-6.541-7.373-9.783-90.011 109.244-195.627 197.517-368.094 197.517-18.851 0-34.133 15.282-34.133 34.133s15.282 34.133 34.133 34.133zM605.695 235.643c-34.109 32.748-65.776 72.196-96.584 113.051 12.917 16.23 25.216 32.363 37.023 48.106l6.135 8.201c33.741-45.339 65.741-86.548 100.704-120.111 49.417-47.438 101.122-75.823 166.228-75.823h54.129l-78.268 78.264c-13.326 13.33-13.326 34.942 0 48.271 13.332 13.33 34.946 13.33 48.278 0l136.533-136.53c13.326-13.332 13.326-34.946 0-48.278l-136.533-136.533c-13.332-13.326-34.946-13.326-48.278 0-13.326 13.332-13.326 34.946 0 48.278l78.268 78.261h-54.129c-88.494 0-156.255 39.881-213.505 94.843z",

                    LoopModes.LoopSingle =>
                        "M146.532,877.469,10,740.936a34.133,34.133,0,0,1,0-48.271L146.532,556.132A34.132,34.132,0,1,1,194.8,604.4l-78.264,78.264H614.4c131.959,0,238.933-106.974,238.933-238.933a34.133,34.133,0,0,1,68.266,0c0,169.662-137.537,307.2-307.2,307.2H116.537L194.8,829.2h0a34.132,34.132,0,0,1-48.271,48.271ZM480.063,597.893V346.884L444.9,382.047a25,25,0,0,1-35.356-35.355l77.841-77.841a25,25,0,0,1,42.678,17.678V597.893a25,25,0,0,1-50,0ZM34.133,443.733c0-169.662,137.538-307.2,307.2-307.2H839.2L760.927,58.272A34.138,34.138,0,0,1,809.205,9.995L945.739,146.527a34.15,34.15,0,0,1,0,48.279L809.205,331.336a34.135,34.135,0,0,1-48.278-48.272L839.2,204.8H341.333C209.374,204.8,102.4,311.774,102.4,443.733h0a34.133,34.133,0,1,1-68.266,0Z",
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
            else
            {
                throw new ApplicationException("转换类型错误.");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}