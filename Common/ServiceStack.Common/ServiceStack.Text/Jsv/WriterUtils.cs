using System;
using System.IO;

namespace ServiceStack.Text.Jsv
{
	public class WriterUtils
	{
		public static void WriteBuiltIn(TextWriter writer, object value)
		{
			writer.Write(value);
		}

		public static void WriteItemSeperatorIfRanOnce(TextWriter writer, ref bool ranOnce)
		{
			if (ranOnce)
				writer.Write(TypeSerializer.ItemSeperator);
			else
				ranOnce = true;
		}

		public static void WriteString(TextWriter writer, string value)
		{
			writer.Write(value.ToCsvField());
		}

		public static void WriteDateTime(TextWriter writer, object oDateTime)
		{
			writer.Write(DateTimeSerializer.ToShortestXsdDateTimeString((DateTime)oDateTime));
		}

		public static void WriteNullableDateTime(TextWriter writer, object dateTime)
		{
			if (dateTime == null) return;
			writer.Write(DateTimeSerializer.ToShortestXsdDateTimeString((DateTime)dateTime));
		}

		public static void WriteGuid(TextWriter writer, object oValue)
		{
			writer.Write(((Guid)oValue).ToString("N"));
		}

		public static void WriteNullableGuid(TextWriter writer, object oValue)
		{
			if (oValue == null) return;
			writer.Write(((Guid)oValue).ToString("N"));
		}

		public static void WriteBytes(TextWriter writer, object oByteValue)
		{
			if (oByteValue == null) return;
			writer.Write(Convert.ToBase64String((byte[])oByteValue));
		}
	}
}