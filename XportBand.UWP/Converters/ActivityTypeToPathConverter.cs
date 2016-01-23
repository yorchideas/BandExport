﻿//-----------------------------------------------------------------------
// <copyright file="BooleanInverseConverter.cs" company="Jorge Alberto Hernández Quirino">
// Copyright (c) Jorge Alberto Hernández Quirino 2014-2016. All rights reserved.
// </copyright>
// <author>Jorge Alberto Hernández Quirino</author>
//-----------------------------------------------------------------------
namespace XportBand.Converters
{
    using System;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Data;
    using MSHealthAPI;

    /// <summary>
    /// Converter class, from <see cref="MSHealthAPI.MSHealthActivityType"/> to <see cref="System.String"/> for <see cref="Windows.UI.Xaml.Shapes.Path.Data"/>.
    /// </summary>
    public sealed class ActivityTypeToPathConverter : IValueConverter
    {

        #region Constants

        private const string ACTIVITY_EXERCISE_PATH = "M28,5.8999939L32,5.8999939 32,7.5 28,7.5z M0,5.8999939L4,5.8999939 4,7.5 0,7.5z M11.5,5.5L20.600006,5.5 20.600006,8 11.5,8z M26.799988,4.6999817L27.600006,4.6999817 27.600006,8.7999878 26.799988,8.7999878z M4.3999939,4.6999817L5.1999817,4.6999817 5.1999817,8.7999878 4.3999939,8.7999878z M24.100006,2.1000061L24.399994,2.1000061 26.299988,2.1000061 26.299988,11.399994 24.100006,11.399994z M5.6000061,2.1000061L5.8999939,2.1000061 7.7999878,2.1000061 7.7999878,11.399994 5.6000061,11.399994z M21,0L21.299988,0 23.699982,0 23.699982,13.5 21,13.5z M8.2999878,0L8.5,0 8.6000061,0 8.6999817,0 11,0 11,13.5 8.2999878,13.5z";
        private const string ACTIVITY_RUN_PATH = "M14.495536,2.4970052C14.995542,2.497005,15.394548,2.6970062,15.794561,3.0960097L15.894554,3.1960082 15.994561,3.1960082 16.193553,3.3960097 24.084649,11.38603 29.07871,6.5920179C29.378716,6.2920177 29.877715,6.0930159 30.277715,6.1930187 30.676721,6.1930187 31.175734,6.3920166 31.475741,6.7920191 32.174739,7.4910223 32.174739,8.5900242 31.475741,9.1890252L25.183661,15.282046C24.583648,15.881046,23.58565,15.881046,22.885631,15.282046L22.686639,15.182046C22.486625,15.08204,22.286626,14.882042,22.186633,14.782044L19.290589,11.786033 16.893573,14.183043 23.684651,21.075061C24.483657,21.874059 24.583648,23.172067 23.784644,23.872066 23.485644,24.171071 23.085645,24.371068 22.586631,24.371068L22.386632,24.371068 22.286626,24.371068 12.897526,24.371068C11.898506,24.371068 11.099501,23.57207 11.099501,22.573066 11.099501,21.574064 11.898506,20.775058 12.897526,20.775058L18.191577,20.775058 14.196536,16.680043 3.1094041,27.86708C2.4104059,28.566079 1.211387,28.666078 0.51237378,27.967078 -0.18662398,27.26708 -0.18662398,26.06907 0.61238126,25.370071L16.693559,9.2890246 16.793567,9.1890252 14.395544,6.7920191 9.5014753,11.486029C8.8024769,12.086037 7.7034659,12.086037 7.1044597,11.38603 6.4054465,10.687031 6.4054465,9.5890276 7.1044597,8.9890282L13.197532,3.0960097 13.297523,2.996007 13.397531,2.8970075C13.69653,2.5970075,14.096529,2.497005,14.495536,2.4970052z M23.185637,0C25.083653,-3.7247446E-08 26.68168,1.5980041 26.68168,3.4960081 26.68168,5.3940165 25.083653,6.9920204 23.185637,6.9920204 21.287621,6.9920204 19.689595,5.3940165 19.689595,3.4960081 19.589602,1.5980041 21.187613,-3.7247446E-08 23.185637,0z";
        private const string ACTIVITY_BIKE_PATH = "M25.918023,18.357008C24.022029,18.357008 22.526029,19.852994 22.526029,21.749006 22.526029,23.645002 24.022029,25.141004 25.918023,25.141004 27.813041,25.141004 29.310018,23.645002 29.310018,21.749006 29.310018,19.953001 27.813041,18.357008 25.918023,18.357008z M6.164044,18.357008C4.2680498,18.357008 2.7720491,19.852994 2.7720491,21.749006 2.7720491,23.645002 4.2680498,25.141004 6.164044,25.141004 8.0600387,25.141004 9.556039,23.645002 9.556039,21.749006 9.6560451,19.953001 8.0600387,18.357008 6.164044,18.357008z M25.918023,16.661008C28.711019,16.661008 31.00603,18.956007 31.00603,21.749006 31.00603,24.542005 28.711019,26.837003 25.918023,26.837003 23.124049,26.837003 20.830045,24.542005 20.830045,21.749006 20.730039,18.956007 23.024043,16.661008 25.918023,16.661008z M6.164044,16.661008C8.9570409,16.661008 11.252051,18.956007 11.252051,21.749006 11.252051,24.542005 8.9570409,26.837003 6.164044,26.837003 3.3710474,26.837003 1.0760667,24.641996 1.0760665,21.749006 1.0760667,18.956007 3.3710474,16.661008 6.164044,16.661008z M25.918023,13.967009C28.611045,13.967009 30.906024,15.164 31.90404,17.160001 32.103015,17.559003 32.003039,18.057996 31.505023,18.257001 31.405017,18.357008 31.205035,18.357008 31.106036,18.357008 30.806018,18.357008 30.507039,18.156995 30.307027,17.857999 29.609029,16.460996 27.813041,15.564009 25.818048,15.564009 23.823024,15.564009 22.027036,16.561002 21.328031,17.958005 21.129026,18.357008 20.630035,18.555997 20.231048,18.357008 19.83203,18.156995 19.632049,17.659009 19.83203,17.260007 20.830045,15.164 23.224025,13.967009 25.918023,13.967009z M6.164044,13.967009C8.5580541,13.967009 10.753059,14.96501 11.95005,16.661008 12.050056,16.760999 12.150062,16.960004 12.250036,17.160001 12.449041,17.559003 12.349035,18.057996 11.85105,18.257001 11.452033,18.456998 10.953041,18.257001 10.753059,17.857999 10.653053,17.758008 10.653053,17.659009 10.554054,17.559003 9.7560512,16.361997 8.0600387,15.564009 6.164044,15.564009 4.2680498,15.564009 2.5720674,16.361997 1.7740642,17.559003 1.7740641,17.659009 1.6750652,17.659009 1.6750653,17.758008 1.4750532,18.057996 1.2750716,18.257001 0.87605487,18.257001 0.77705579,18.257001 0.57704376,18.257001 0.47706827,18.156995 0.078051313,17.958005 -0.12095363,17.458997 0.078051127,17.059995 0.17805732,16.960004 0.17805732,16.859998 0.27806323,16.661008 1.4750532,15.065001 3.6700584,13.967009 6.164044,13.967009z M18.535035,3.6910091C19.134032,3.6910093 19.732055,3.8910062 20.231048,4.3899989 20.331054,4.488998 20.431029,4.6890102 20.530028,4.789001L20.630035,4.9880061 23.224025,8.8789973 26.915031,7.9810019C27.614036,7.7819967 28.41204,8.2810054 28.512046,8.9790034 28.711019,9.6770005 28.212028,10.475005 27.51403,10.574996L23.024043,11.572997 22.725032,11.572997C22.326047,11.572997,21.827024,11.373,21.628049,10.973998L19.732055,8.1809993 15.14304,12.97 17.936036,15.564009C18.335054,15.962996,18.535035,16.561002,18.236055,17.059995L15.742038,23.046003 17.039033,24.941007C17.43805,25.540006 17.238038,26.438001 16.639041,26.837003 16.440036,27.037 16.141055,27.037 15.841037,27.037 15.44205,27.037 14.943058,26.837003 14.744053,26.438001L13.048041,23.943998C12.74906,23.544996,12.74906,23.046003,12.948034,22.647001L15.342044,16.859998 11.551032,13.369002 11.452033,13.369002 11.352058,13.268996C11.152046,13.068999 11.053047,12.97 11.053047,12.669997 10.653053,11.772002 10.753059,10.775008 11.452033,9.9770036L16.939027,4.3899989C17.338044,3.8910062,17.936036,3.6910093,18.535035,3.6910091z M23.224025,0C24.720025,1.456674E-07 25.918023,1.1970062 25.918023,2.6939998 25.918023,4.190002 24.720025,5.3870082 23.224025,5.3870082 21.728025,5.3870082 20.530028,4.190002 20.530028,2.6939998 20.530028,1.1970062 21.728025,1.456674E-07 23.224025,0z";
        private const string ACTIVITY_GOLF_PATH = "M2.0999756,26.199996C3,26.400001,4.2000122,26.199996,4.2000122,26.199996L3.3999634,26.999999 3.3999634,29.400001 2.8999631,29.400001 2.7999878,26.999999z M3.0999758,19.799995C4.7999878,19.799995 6.2000122,21.199996 6.2000122,22.900001 6.2000122,24.599998 4.7999878,25.999999 3.0999758,25.999999 1.3999634,25.999999 0,24.599998 0,22.900001 0,21.199996 1.3999634,19.799995 3.0999758,19.799995z M31.099976,1.7485036E-10C31.299988,-9.1337938E-08 31.5,-9.1337938E-08 31.599976,0.099998406 32,0.39999761 32.099976,0.99999981 31.899963,1.3999976L28.299988,7.099998C28.200012,7.2999988,28,7.3999973,27.799988,7.4999996L16.299988,26.699996 14.799988,28.900001C14.799988,28.900001 11,30.099996 9.2000122,28.400001 7.2999878,26.499999 7,22.799995 11.799988,24.499999 11.899963,24.499999 11.899963,24.599998 12,24.599998 12,24.599998 14.299988,25.599998 15,26.199996L26.599976,6.7999988C26.599976,6.599998,26.599976,6.3999973,26.700012,6.2000003L30.299988,0.49999963C30.5,0.20000066,30.799988,-9.1337938E-08,31.099976,1.7485036E-10z";
        private const string ACTIVITY_SLEEP_PATH = "M9.7000122,5.9000223L9.8000488,5.9000223 30.100037,5.9000223C31.100037,5.9999978,32,6.8000157,32,7.8000152L32,10.999995 5.7000122,10.999995 4.5,10.999995 3.3000488,10.999995 3.3000488,8.7000086 4.4000244,8.7000086 9.7000122,8.7000086z M6.4000244,3.4999986C7.7000122,3.4999986 8.8000488,4.4999983 8.8000488,5.9000223 8.8000488,7.2000096 7.7000122,8.3000147 6.4000244,8.3000147 5.1000366,8.2000086 4,7.1000035 4,5.8000161 4,4.4999983 5.1000366,3.4999986 6.4000244,3.4999986z M0,0L2.6000366,0 2.6000366,1.4000234 2.6000366,5.6000039 2.6000366,12.100002 32,12.100002 32,18.6 29.400024,18.6 29.400024,14.600001 2.6000366,14.600001 2.6000366,18.6 0,18.6 0,5.6000039 0,1.4000234z";
        private const string ACTIVITY_GUIDED_PATH = "M10.540996,23.457004L19.728996,23.457004 19.728996,26.017978 10.540996,26.017978z M5.4190043,23.457004L8.967007,23.457004 8.967007,26.017978 5.4190043,26.017978z M10.540996,18.523994L19.728996,18.523994 19.728996,21.086004 10.540996,21.086004z M5.4190043,18.523994L8.967007,18.523994 8.967007,21.086004 5.4190043,21.086004z M10.540996,13.591989L19.728996,13.591989 19.728996,16.152992 10.540996,16.152992z M5.4190043,13.591989L8.967007,13.591989 8.967007,16.152992 5.4190043,16.152992z M10.540996,8.6580004L19.728996,8.6580004 19.728996,11.219996 10.540996,11.219996z M5.4190043,8.6580004L8.967007,8.6580004 8.967007,11.219996 5.4190043,11.219996z M0,3.1249985L3.5510085,3.1249985 3.5510085,28.45099 21.301994,28.45099 21.301994,3.1249985 24.855001,3.1249985 24.855001,28.45099 24.855001,31.999999 21.301994,31.999999 3.5510085,31.999999 1.3320002,31.999999 0,31.999999z M10.307002,1.1309963L10.307002,3.1249985 14.415003,3.1249985 14.415003,1.1309963z M9.0369991,0L15.683999,0 15.683999,3.1249985 18.749,3.1249985 18.749,5.6849946 5.9739969,5.6849946 5.9739969,3.1249985 9.0369991,3.1249985z";

        #endregion

        #region IValueConverter implementation

        /// <summary>
        /// Modifies the source data before passing it to the target for display in the UI.
        /// </summary>
        /// <param name="value">The source data being passed to the target.</param>
        /// <param name="targetType">The type of the target property, as a type reference.</param>
        /// <param name="parameter">An optional parameter to be used in the converter logic.</param>
        /// <param name="language">The language of the conversion.</param>
        /// <returns>The value to be passed to the target dependency property.</returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string lsPath = null;
            MSHealthActivityType loType;

            if (value is MSHealthActivityType)
            {
                loType = (MSHealthActivityType)value;
                switch (loType)
                {
                    case MSHealthActivityType.Run:
                        lsPath = ACTIVITY_RUN_PATH;
                        break;
                    case MSHealthActivityType.Bike:
                        lsPath = ACTIVITY_BIKE_PATH;
                        break;
                    case MSHealthActivityType.Golf:
                        lsPath = ACTIVITY_GOLF_PATH;
                        break;
                    case MSHealthActivityType.Sleep:
                        lsPath = ACTIVITY_SLEEP_PATH;
                        break;
                    case MSHealthActivityType.GuidedWorkout:
                        lsPath = ACTIVITY_GUIDED_PATH;
                        break;
                    default:
                        lsPath = ACTIVITY_EXERCISE_PATH;
                        break;
                }
            }

            return lsPath;
        }

        /// <summary>
        /// Modifies the target data before passing it to the source object. This method is called only in TwoWay bindings.
        /// </summary>
        /// <param name="value">The target data being passed to the source.</param>
        /// <param name="targetType">The type of the target property, as a type reference.</param>
        /// <param name="parameter">An optional parameter to be used in the converter logic.</param>
        /// <param name="language">The language of the conversion.</param>
        /// <returns>The value to be passed to the source object.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        #endregion

    }

}