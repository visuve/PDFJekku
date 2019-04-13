# PDF Jekku

- Inject JavaScript into PDF documents
- Made for demonstration purposes

Two implementations exist for a reason:
- I first created the app in C# using BitMiracle Docotic which is criminally expensive
    - I used the evaluation version which leaves the nasty watermark and got annoyed
        - Then I went ahead and wrote it in Python 3 too and use the free PyPDF3 library
            - The PyPDF3 seems to has it's bugs too...