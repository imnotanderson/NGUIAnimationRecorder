using UnityEngine;
using System.Collections;


[ExecuteInEditMode]
public class UIWidgetRecord : MonoBehaviour
{
    [HideInInspector]
    public float mWidth, mHeight;
    float tmWidth, tmHeight;

    UIWidget mWidget = null;

    UIWidget widget
    {
        get
        {
            if (mWidget == null)
            {
                mWidget = GetComponent<UIWidget>();
                if (mWidget != null)
                {
                    mWidth = mWidget.width;
                    mHeight = mWidget.height;
                }
            }
            return mWidget;
        }
    }

    void UpdateWidth()
    {
        if (tmWidth == mWidth)
        {
            return;
        }
        if (widget == null)
        {
            return;
        }
        if (widget.width != (int)mWidth)
        {
            widget.width = (int)(mWidth);
            tmWidth = mWidth;
        }
    }

    void UpdateHeight()
    {
        if(tmHeight == mHeight)
        {
            return;
        }
        if (widget == null) return;
        if (widget.height != (int)mHeight)
        {
            widget.height = (int)(mHeight);
            tmHeight = mHeight;
        }
    }


    public void MakePixelPerfect()
    {
        if (widget == null) return;
        if (widget is UISprite)
        {
            UISprite sprite = widget as UISprite;
            UISpriteData sp = sprite.GetAtlasSprite();
            if (sp == null) return;

            Texture tex = sprite.mainTexture;
            if (tex == null) return;

            if (sprite.type == UISprite.Type.Simple || sprite.type == UISprite.Type.Filled || !sp.hasBorder)
            {
                if (tex != null)
                {
                    int x = Mathf.RoundToInt(sprite.pixelSize * (sp.width + sp.paddingLeft + sp.paddingRight));
                    int y = Mathf.RoundToInt(sprite.pixelSize * (sp.height + sp.paddingTop + sp.paddingBottom));

                    if ((x & 1) == 1) ++x;
                    if ((y & 1) == 1) ++y;

                    mWidth = x;
                    mHeight = y;
                }
            }
        }
    }

    void UpdateSize()
    {
        UpdateWidth();
        UpdateHeight();
    }

    public void OnRenderObject()
    {
        UpdateSize();
    }


}
