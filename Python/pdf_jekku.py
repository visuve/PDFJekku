import argparse
import PyPDF3

'''
Inserts JavaScript into an existing PDF document or creates a new blank PDF.
Same as the C# project, but written in Python3.
Author: visuve
'''

parser = argparse.ArgumentParser(
    description="Insert JavaScript into a PDF document.")

parser.add_argument(
    "--pdf", type=str, required=False, help="Path to existing PDF file. Omit to create a blank new PDF with the JS.")
parser.add_argument(
    "--js", type=str, required=True, help="Path to JavaScript file")
parser.add_argument(
    "--out", type=str,  required=True, help="Output path for resulting PDF file")

args = parser.parse_args()

writer = PyPDF3.PdfFileWriter()

if args.pdf is not None:
    reader = PyPDF3.PdfFileReader(args.pdf, strict=False)
    writer.cloneDocumentFromReader(reader)

with open(args.js) as js_file:
    js_content = js_file.read()
    writer.addJS(js_content)

with open(args.out, "wb") as output_pdf:
    writer.write(output_pdf)
