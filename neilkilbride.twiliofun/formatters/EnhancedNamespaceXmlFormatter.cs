﻿using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace neilkilbride.twiliofun.formatters
{
    public class EnhancedNamespaceXmlFormatter : XmlMediaTypeFormatter
    {
        public override async Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
        {
            try
            {
                var xns = new XmlSerializerNamespaces();
                foreach (var attribute in type.GetCustomAttributes(true))
                {
                    var xmlRootAttribute = attribute as XmlRootAttribute;
                    if (xmlRootAttribute != null)
                    {
                        xns.Add(string.Empty, xmlRootAttribute.Namespace);
                    }
                }

                if (xns.Count == 0)
                {
                    xns.Add(string.Empty, string.Empty);
                }

                var xmlTextWriter = new XmlTextWriter(writeStream, Encoding.UTF8);
                var serializer = new XmlSerializer(type);
                serializer.Serialize(xmlTextWriter, value, xns);
            }
            catch (Exception ex)
            {
                await base.WriteToStreamAsync(type, value, writeStream, content, transportContext);
            }
        }
    }
}