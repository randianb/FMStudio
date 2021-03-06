﻿using System.Windows.Media;

namespace System.Windows
{
    public static class DependencyObjectExtensions
    {
        public static T FindAncestor<T>(this DependencyObject current)
            where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }
    }
}