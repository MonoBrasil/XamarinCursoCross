using System;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.CoreGraphics;
using MonoTouch.Foundation;

namespace PaintCode
{
	[Register("PaintCode")]
	public class PaintCode : UIButton
	{
		public PaintCode ()
		{
		}

		public PaintCode (RectangleF rect) : base (rect) {
		}

		public PaintCode (IntPtr handle)
		{
			this.Handle = handle;
		}

		public override void Draw (System.Drawing.RectangleF rect)
		{
			base.Draw (rect);

			//// General Declarations
			var colorSpace = CGColorSpace.CreateDeviceRGB();
			var context = UIGraphics.GetCurrentContext();

			//// Color Declarations
			UIColor symbolShadow = UIColor.FromRGBA(0.496f, 0.496f, 0.496f, 1.000f);
			UIColor symbolONColor = UIColor.FromRGBA(0.798f, 0.949f, 1.000f, 1.000f);
			UIColor backGroundColorTop = UIColor.FromRGBA(0.769f, 0.813f, 0.827f, 1.000f);
			var backGroundColorTopHSBA = new float[4];
			backGroundColorTop.GetHSBA(out backGroundColorTopHSBA[0], out backGroundColorTopHSBA[1], out backGroundColorTopHSBA[2], out backGroundColorTopHSBA[3]);

			UIColor backGroundColorBottom = UIColor.FromHSBA(backGroundColorTopHSBA[0], 0.154f, backGroundColorTopHSBA[2], backGroundColorTopHSBA[3]);
			UIColor smallShadowColor = UIColor.FromRGBA(0.296f, 0.296f, 0.296f, 1.000f);
			UIColor testColor = UIColor.FromRGBA(1.000f, 1.000f, 1.000f, 1.000f);
			UIColor baseColor2 = UIColor.FromRGBA(0.260f, 0.451f, 0.745f, 1.000f);
			var baseColor2RGBA = new float[4];
			baseColor2.GetRGBA(out baseColor2RGBA[0], out baseColor2RGBA[1], out baseColor2RGBA[2], out baseColor2RGBA[3]);

			var baseColor2HSBA = new float[4];
			baseColor2.GetHSBA(out baseColor2HSBA[0], out baseColor2HSBA[1], out baseColor2HSBA[2], out baseColor2HSBA[3]);

			UIColor bottomColor2 = UIColor.FromHSBA(baseColor2HSBA[0], baseColor2HSBA[1], 0.8f, baseColor2HSBA[3]);
			var bottomColor2RGBA = new float[4];
			bottomColor2.GetRGBA(out bottomColor2RGBA[0], out bottomColor2RGBA[1], out bottomColor2RGBA[2], out bottomColor2RGBA[3]);

			UIColor bottomOutColor2 = UIColor.FromRGBA((bottomColor2RGBA[0] * 0.9f), (bottomColor2RGBA[1] * 0.9f), (bottomColor2RGBA[2] * 0.9f), (bottomColor2RGBA[3] * 0.9f + 0.1f));
			UIColor topColor2 = UIColor.FromRGBA((baseColor2RGBA[0] * 0.2f + 0.8f), (baseColor2RGBA[1] * 0.2f + 0.8f), (baseColor2RGBA[2] * 0.2f + 0.8f), (baseColor2RGBA[3] * 0.2f + 0.8f));
			var topColor2RGBA = new float[4];
			topColor2.GetRGBA(out topColor2RGBA[0], out topColor2RGBA[1], out topColor2RGBA[2], out topColor2RGBA[3]);

			UIColor topOutColor2 = UIColor.FromRGBA((topColor2RGBA[0] * 0 + 1), (topColor2RGBA[1] * 0 + 1), (topColor2RGBA[2] * 0 + 1), (topColor2RGBA[3] * 0 + 1));

			//// Gradient Declarations
			var backgroundGradientColors = new CGColor [] {backGroundColorTop.CGColor, backGroundColorBottom.CGColor};
			var backgroundGradientLocations = new float [] {0, 1};
			var backgroundGradient = new CGGradient(colorSpace, backgroundGradientColors, backgroundGradientLocations);
			var buttonOutGradient2Colors = new CGColor [] {bottomOutColor2.CGColor, UIColor.FromRGBA(0.625f, 0.718f, 0.860f, 1.000f).CGColor, topOutColor2.CGColor};
			var buttonOutGradient2Locations = new float [] {0, 0.69f, 1};
			var buttonOutGradient2 = new CGGradient(colorSpace, buttonOutGradient2Colors, buttonOutGradient2Locations);
			var buttonGradient2Colors = new CGColor [] {bottomColor2.CGColor, topColor2.CGColor};
			var buttonGradient2Locations = new float [] {0, 1};
			var buttonGradient2 = new CGGradient(colorSpace, buttonGradient2Colors, buttonGradient2Locations);

			//// Shadow Declarations
			var shadow = symbolShadow.CGColor;
			var shadowOffset = new SizeF(0.1f, 210.1f);
			var shadowBlurRadius = 15;
			var glow = symbolONColor.CGColor;
			var glowOffset = new SizeF(0.1f, -0.1f);
			var glowBlurRadius = 7.5f;
			var smallShadow = smallShadowColor.CGColor;
			var smallShadowOffset = new SizeF(0.1f, 3.1f);
			var smallShadowBlurRadius = 5.5f;

			//// Frames
			var frame = new RectangleF(0, 0, 120, 130);

			//// Subframes
			var symbol = new RectangleF(frame.GetMinX() + 39, frame.GetMinY() + 35, frame.Width - 77, frame.Height - 85);

			//// BackgroundGroup
			{
				context.SaveState();
				context.SetAlpha(0.38f);
				context.BeginTransparencyLayer();

				//// background Drawing
				var backgroundPath = UIBezierPath.FromRect(new RectangleF(-60, -56, 250, 240));
				context.SaveState();
				backgroundPath.AddClip();
				context.DrawLinearGradient(backgroundGradient, new PointF(65, -56), new PointF(65, 184), 0);
				context.RestoreState();

				context.EndTransparencyLayer();
				context.RestoreState();
			}


			//// GroupShadow
			{
				context.SaveState();
				context.SetAlpha(0.75f);
				context.SetBlendMode(CGBlendMode.Multiply);
				context.BeginTransparencyLayer();

				//// LongShadow Drawing
				UIBezierPath longShadowPath = new UIBezierPath();
				longShadowPath.MoveTo(new PointF(58.79f, -91.94f));
				longShadowPath.AddCurveToPoint(new PointF(94.83f, -171.47f), new PointF(105.69f, -91.51f), new PointF(108.82f, -151.54f));
				longShadowPath.AddCurveToPoint(new PointF(58.79f, -191.24f), new PointF(91.21f, -176.63f), new PointF(83.49f, -191.41f));
				longShadowPath.AddCurveToPoint(new PointF(23.82f, -171.47f), new PointF(34.73f, -191.08f), new PointF(26.78f, -176.84f));
				longShadowPath.AddCurveToPoint(new PointF(58.79f, -91.94f), new PointF(11.99f, -149.99f), new PointF(15.59f, -92.33f));
				longShadowPath.ClosePath();
				context.SaveState();
				context.SetShadowWithColor(shadowOffset, shadowBlurRadius, shadow);
				baseColor2.SetFill();
				longShadowPath.Fill();
				context.RestoreState();

				context.EndTransparencyLayer();
				context.RestoreState();
			}


			//// outerRing Drawing
			var outerRingRect = new RectangleF(frame.GetMinX() + 15.5f, frame.GetMinY() + 13.5f, frame.Width - 31, frame.Height - 41);
			var outerRingPath = UIBezierPath.FromOval(outerRingRect);
			context.SaveState();
			context.SetShadowWithColor(smallShadowOffset, smallShadowBlurRadius, smallShadow);
			context.BeginTransparencyLayer(null);
			outerRingPath.AddClip();
			context.DrawLinearGradient(buttonOutGradient2,
				new PointF(outerRingRect.GetMidX(), outerRingRect.GetMaxY()),
				new PointF(outerRingRect.GetMidX(), outerRingRect.GetMinY()),
				0);
			context.EndTransparencyLayer();
			context.RestoreState();



			//// innerRing Drawing
			var innerRingRect = new RectangleF(frame.GetMinX() + 18.5f, frame.GetMinY() + 16.5f, frame.Width - 37, frame.Height - 47);
			var innerRingPath = UIBezierPath.FromOval(innerRingRect);
			context.SaveState();
			innerRingPath.AddClip();
			context.DrawLinearGradient(buttonGradient2,
				new PointF(innerRingRect.GetMidX(), innerRingRect.GetMaxY()),
				new PointF(innerRingRect.GetMidX(), innerRingRect.GetMinY()),
				0);
			context.RestoreState();


			//// Symbol
			{
				//// symbolON Drawing
				UIBezierPath symbolONPath = new UIBezierPath();
				symbolONPath.MoveTo(new PointF(symbol.GetMinX() + 0.50194f * symbol.Width, symbol.GetMinY() + 0.04446f * symbol.Height));
				symbolONPath.AddLineTo(new PointF(symbol.GetMinX() + 0.49855f * symbol.Width, symbol.GetMinY() + 0.04445f * symbol.Height));
				symbolONPath.AddLineTo(new PointF(symbol.GetMinX() + 0.50194f * symbol.Width, symbol.GetMinY() + 0.04446f * symbol.Height));
				symbolONPath.ClosePath();
				symbolONPath.MoveTo(new PointF(symbol.GetMinX() + 0.85355f * symbol.Width, symbol.GetMinY() + 0.18438f * symbol.Height));
				symbolONPath.AddCurveToPoint(new PointF(symbol.GetMinX() + 0.85355f * symbol.Width, symbol.GetMinY() + 0.86006f * symbol.Height), new PointF(symbol.GetMinX() + 1.04882f * symbol.Width, symbol.GetMinY() + 0.37097f * symbol.Height), new PointF(symbol.GetMinX() + 1.04882f * symbol.Width, symbol.GetMinY() + 0.67348f * symbol.Height));
				symbolONPath.AddCurveToPoint(new PointF(symbol.GetMinX() + 0.14645f * symbol.Width, symbol.GetMinY() + 0.86006f * symbol.Height), new PointF(symbol.GetMinX() + 0.65829f * symbol.Width, symbol.GetMinY() + 1.04665f * symbol.Height), new PointF(symbol.GetMinX() + 0.34171f * symbol.Width, symbol.GetMinY() + 1.04665f * symbol.Height));
				symbolONPath.AddCurveToPoint(new PointF(symbol.GetMinX() + 0.14645f * symbol.Width, symbol.GetMinY() + 0.18438f * symbol.Height), new PointF(symbol.GetMinX() + -0.04882f * symbol.Width, symbol.GetMinY() + 0.67348f * symbol.Height), new PointF(symbol.GetMinX() + -0.04882f * symbol.Width, symbol.GetMinY() + 0.37097f * symbol.Height));
				symbolONPath.AddCurveToPoint(new PointF(symbol.GetMinX() + 0.25581f * symbol.Width, symbol.GetMinY() + 0.18889f * symbol.Height), new PointF(symbol.GetMinX() + 0.17353f * symbol.Width, symbol.GetMinY() + 0.16157f * symbol.Height), new PointF(symbol.GetMinX() + 0.22375f * symbol.Width, symbol.GetMinY() + 0.16086f * symbol.Height));
				symbolONPath.AddCurveToPoint(new PointF(symbol.GetMinX() + 0.26156f * symbol.Width, symbol.GetMinY() + 0.29438f * symbol.Height), new PointF(symbol.GetMinX() + 0.28788f * symbol.Width, symbol.GetMinY() + 0.21692f * symbol.Height), new PointF(symbol.GetMinX() + 0.28490f * symbol.Width, symbol.GetMinY() + 0.27238f * symbol.Height));
				symbolONPath.AddCurveToPoint(new PointF(symbol.GetMinX() + 0.26156f * symbol.Width, symbol.GetMinY() + 0.75007f * symbol.Height), new PointF(symbol.GetMinX() + 0.12987f * symbol.Width, symbol.GetMinY() + 0.42021f * symbol.Height), new PointF(symbol.GetMinX() + 0.12987f * symbol.Width, symbol.GetMinY() + 0.62423f * symbol.Height));
				symbolONPath.AddCurveToPoint(new PointF(symbol.GetMinX() + 0.73844f * symbol.Width, symbol.GetMinY() + 0.75007f * symbol.Height), new PointF(symbol.GetMinX() + 0.39325f * symbol.Width, symbol.GetMinY() + 0.87590f * symbol.Height), new PointF(symbol.GetMinX() + 0.60675f * symbol.Width, symbol.GetMinY() + 0.87590f * symbol.Height));
				symbolONPath.AddCurveToPoint(new PointF(symbol.GetMinX() + 0.73844f * symbol.Width, symbol.GetMinY() + 0.29438f * symbol.Height), new PointF(symbol.GetMinX() + 0.87013f * symbol.Width, symbol.GetMinY() + 0.62423f * symbol.Height), new PointF(symbol.GetMinX() + 0.87013f * symbol.Width, symbol.GetMinY() + 0.42021f * symbol.Height));
				symbolONPath.AddCurveToPoint(new PointF(symbol.GetMinX() + 0.73844f * symbol.Width, symbol.GetMinY() + 0.18438f * symbol.Height), new PointF(symbol.GetMinX() + 0.70569f * symbol.Width, symbol.GetMinY() + 0.26272f * symbol.Height), new PointF(symbol.GetMinX() + 0.70967f * symbol.Width, symbol.GetMinY() + 0.21188f * symbol.Height));
				symbolONPath.AddCurveToPoint(new PointF(symbol.GetMinX() + 0.85355f * symbol.Width, symbol.GetMinY() + 0.18438f * symbol.Height), new PointF(symbol.GetMinX() + 0.76722f * symbol.Width, symbol.GetMinY() + 0.15688f * symbol.Height), new PointF(symbol.GetMinX() + 0.83173f * symbol.Width, symbol.GetMinY() + 0.15986f * symbol.Height));
				symbolONPath.ClosePath();
				symbolONPath.MoveTo(new PointF(symbol.GetMinX() + 0.41860f * symbol.Width, symbol.GetMinY() + 0.52222f * symbol.Height));
				symbolONPath.AddCurveToPoint(new PointF(symbol.GetMinX() + 0.50000f * symbol.Width, symbol.GetMinY() + 0.60000f * symbol.Height), new PointF(symbol.GetMinX() + 0.41860f * symbol.Width, symbol.GetMinY() + 0.56518f * symbol.Height), new PointF(symbol.GetMinX() + 0.45505f * symbol.Width, symbol.GetMinY() + 0.60000f * symbol.Height));
				symbolONPath.AddCurveToPoint(new PointF(symbol.GetMinX() + 0.58140f * symbol.Width, symbol.GetMinY() + 0.52222f * symbol.Height), new PointF(symbol.GetMinX() + 0.54495f * symbol.Width, symbol.GetMinY() + 0.60000f * symbol.Height), new PointF(symbol.GetMinX() + 0.58140f * symbol.Width, symbol.GetMinY() + 0.56518f * symbol.Height));
				symbolONPath.AddLineTo(new PointF(symbol.GetMinX() + 0.58140f * symbol.Width, symbol.GetMinY() + 0.07778f * symbol.Height));
				symbolONPath.AddCurveToPoint(new PointF(symbol.GetMinX() + 0.50000f * symbol.Width, symbol.GetMinY() + 0.00000f * symbol.Height), new PointF(symbol.GetMinX() + 0.58140f * symbol.Width, symbol.GetMinY() + 0.03482f * symbol.Height), new PointF(symbol.GetMinX() + 0.54495f * symbol.Width, symbol.GetMinY() + 0.00000f * symbol.Height));
				symbolONPath.AddCurveToPoint(new PointF(symbol.GetMinX() + 0.41860f * symbol.Width, symbol.GetMinY() + 0.07778f * symbol.Height), new PointF(symbol.GetMinX() + 0.45505f * symbol.Width, symbol.GetMinY() + 0.00000f * symbol.Height), new PointF(symbol.GetMinX() + 0.41860f * symbol.Width, symbol.GetMinY() + 0.03482f * symbol.Height));
				symbolONPath.AddLineTo(new PointF(symbol.GetMinX() + 0.41860f * symbol.Width, symbol.GetMinY() + 0.52222f * symbol.Height));
				symbolONPath.ClosePath();
				context.SaveState();
				context.SetShadowWithColor(glowOffset, glowBlurRadius, glow);
				testColor.SetFill();
				symbolONPath.Fill();
				context.RestoreState();

			}
		}
	}
}

