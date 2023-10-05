/* ------------------------------------------------------------------------- */
//
// Copyright (c) 2010 CubeSoft, Inc.
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published
// by the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
//
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
//
/* ------------------------------------------------------------------------- */
namespace Cube.Pdf.Converter;

using Cube.Globalization;

/* ------------------------------------------------------------------------- */
///
/// JapaneseText
///
/// <summary>
/// Provides the functionality to get the Japanese text group.
/// </summary>
///
/* ------------------------------------------------------------------------- */
internal static class JapaneseText
{
    /* --------------------------------------------------------------------- */
    ///
    /// Get
    ///
    /// <summary>
    /// Gets the Japanese text group.
    /// </summary>
    ///
    /// <returns>Text group.</returns>
    ///
    /* --------------------------------------------------------------------- */
    public static TextGroup Get() => new()
    {
        // Buttons
        { nameof(Text.Ui_Convert), "変換" },
        { nameof(Text.Ui_Cancel), "キャンセル" },
        { nameof(Text.Ui_SaveSettings), "設定を保存" },

        // Tabs
        { nameof(Text.Ui_General), "一般" },
        { nameof(Text.Ui_Metadata), "文書プロパティ" },
        { nameof(Text.Ui_Security), "セキュリティ" },
        { nameof(Text.Ui_Others), "その他" },

        // Labels for General tab
        { nameof(Text.Ui_Source), "入力ファイル" },
        { nameof(Text.Ui_Destination), "出力ファイル" },
        { nameof(Text.Ui_Format), "ファイルタイプ" },
        { nameof(Text.Ui_Color), "カラーモード" },
        { nameof(Text.Ui_Resolution), "解像度" },
        { nameof(Text.Ui_Orientation), "ページの向き" },
        { nameof(Text.Ui_Options), "オプション" },
        { nameof(Text.Ui_PostProcess), "ポストプロセス" },

        // Labels for Metadata tab
        { nameof(Text.Ui_Title), "タイトル" },
        { nameof(Text.Ui_Author), "作成者" },
        { nameof(Text.Ui_Subject), "サブタイトル" },
        { nameof(Text.Ui_Keyword), "キーワード" },
        { nameof(Text.Ui_PageLayout), "ページレイアウト" },

        // Labels for Security tab
        { nameof(Text.Ui_OwnerPassword), "管理用パスワード" },
        { nameof(Text.Ui_UserPassword), "閲覧用パスワード" },
        { nameof(Text.Ui_ConfirmPassword), "パスワード確認" },
        { nameof(Text.Ui_Operations), "操作" },

        // Labels for Others tab
        { nameof(Text.Ui_About), "バージョン情報" },
        { nameof(Text.Ui_Language), "表示言語" },

        // Menus for General tab (ComboBox, CheckBox, ...)
        { nameof(Text.Menu_Overwrite), "上書き" },
        { nameof(Text.Menu_MergeHead), "先頭に結合" },
        { nameof(Text.Menu_MergeTail), "末尾に結合" },
        { nameof(Text.Menu_Rename), "リネーム" },
        { nameof(Text.Menu_Auto), "自動" },
        { nameof(Text.Menu_Rgb), "RGB" },
        { nameof(Text.Menu_Grayscale), "グレースケール" },
        { nameof(Text.Menu_Monochrome), "白黒" },
        { nameof(Text.Menu_Portrait), "縦" },
        { nameof(Text.Menu_Landscape), "横" },
        { nameof(Text.Menu_Jpg), "PDF ファイル中の画像を JPEG 形式で圧縮する" },
        { nameof(Text.Menu_Linearization), "PDF ファイルを Web 表示用に最適化する" },
        { nameof(Text.Menu_Open), "開く" },
        { nameof(Text.Menu_OpenDirectory), "フォルダーを開く" },
        { nameof(Text.Menu_None), "何もしない" },
        { nameof(Text.Menu_UserProgram), "その他" },

        // Menus for Metadata tab (ComboBox, CheckBox, ...)
        { nameof(Text.Menu_SinglePage), "単一ページ" },
        { nameof(Text.Menu_OneColumn), "連続ページ" },
        { nameof(Text.Menu_TwoPageLeft), "見開きページ（左綴じ）" },
        { nameof(Text.Menu_TwoPageRight), "見開きページ（右綴じ）" },
        { nameof(Text.Menu_TwoColumnLeft), "連続見開きページ（左綴じ）" },
        { nameof(Text.Menu_TwoColumnRight), "連続見開きページ（右綴じ）" },

        // Menus for Security tab (ComboBox, CheckBox, ...)
        { nameof(Text.Menu_EnableSecurity), "PDF ファイルをパスワードで保護する" },
        { nameof(Text.Menu_OpenWithPassword), "PDF ファイルを開く時にパスワードを要求する" },
        { nameof(Text.Menu_SharePassword), "管理用パスワードと共用する" },
        { nameof(Text.Menu_AllowPrint), "印刷を許可する" },
        { nameof(Text.Menu_AllowCopy), "テキストや画像のコピーを許可する" },
        { nameof(Text.Menu_AllowModify), "ページの挿入、回転、削除を許可する" },
        { nameof(Text.Menu_AllowAccessibility), "アクセシビリティのための内容の抽出を許可する" },
        { nameof(Text.Menu_AllowForm), "フォームへの入力を許可する" },
        { nameof(Text.Menu_AllowAnnotation), "注釈の追加、編集を許可する" },

        // Menus for Others tab (ComboBox, CheckBox, ...)
        { nameof(Text.Menu_CheckUpdate), "起動時にアップデートを確認する" },

        // Titles for dialogs
        { nameof(Text.Title_Source), "入力ファイルを選択" },
        { nameof(Text.Title_Destination), "名前を付けて保存" },
        { nameof(Text.Title_UserProgram), "変換完了時に実行するプログラムを選択" },

        // Error messages
        { nameof(Text.Error_Source), "入力ファイルが指定されていません。正常な手順で CubePDF が実行されたかどうか確認して下さい。" },
        { nameof(Text.Error_Digest), "入力ファイルのハッシュ値が一致しません。入力ファイルが破損したか、または改ざんされた可能性があります。" },
        { nameof(Text.Error_Ghostscript), "Ghostscript API による変換中にエラーが発生しました。({0:D})" },
        { nameof(Text.Error_InvalidChars), "ファイル名に次の文字を使用する事はできません。" },
        { nameof(Text.Error_OwnerPassword), "パスワードが入力されていないか、または確認欄と一致しません。パスワードおよびパスワード確認欄を確認して下さい。" },
        { nameof(Text.Error_UserPassword), "閲覧用パスワードが入力されていないか、または確認欄と一致しません。パスワードを再度ご確認するか、「管理用パスワードと共用する」の項目を有効にして下さい。" },
        { nameof(Text.Error_MergePassword), "結合対象として指定された PDF ファイルの管理用パスワードをセキュリティタブに入力して下さい。" },
        { nameof(Text.Error_PostProcess), "変換処理は正常に完了しましたが、ポストプロセスの実行に失敗しました。ファイルの関連付けやユーザープログラムの設定を確認して下さい。" },

        // Warning/Confirm messages
        { nameof(Text.Warn_Exist), "{0} は既に存在します。" },
        { nameof(Text.Warn_Overwrite), "上書きしますか？" },
        { nameof(Text.Warn_MergeHead), "先頭に結合しますか？" },
        { nameof(Text.Warn_MergeTail), "末尾に結合しますか？" },
        { nameof(Text.Warn_Metadata), "タイトル、作成者、サブタイトル、キーワードのいずれかの項目が入力されています。これらの内容は次回以降、CubePDF 起動時の初期設定として利用されます。設定を保存しても良いですか？" },

        // File filters
        { nameof(Text.Filter_All), "すべてのファイル" },
        { nameof(Text.Filter_Pdf), "PDF ファイル" },
        { nameof(Text.Filter_Ps), "PS ファイル" },
        { nameof(Text.Filter_Eps), "EPS ファイル" },
        { nameof(Text.Filter_Bmp), "BMP ファイル" },
        { nameof(Text.Filter_Png), "PNG ファイル" },
        { nameof(Text.Filter_Jpg), "JPEG ファイル" },
        { nameof(Text.Filter_Tiff), "TIFF ファイル" },
        { nameof(Text.Filter_Exe), "実行可能なファイル" },
    };
}
